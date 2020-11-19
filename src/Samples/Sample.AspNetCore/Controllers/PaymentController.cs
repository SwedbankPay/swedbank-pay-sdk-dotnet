using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Cart cartService;
        private readonly StoreDbContext context;
        private readonly ISwedbankPayClient swedbankPayClient;


        public PaymentController(Cart cart, StoreDbContext dbContext, ISwedbankPayClient payClient)
        {
            cartService = cart;
            context = dbContext;
            swedbankPayClient = payClient;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AbortPaymentOrder(string paymentOrderId)
        {
            try
            {
                var paymentOrder = await swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

                var response = await paymentOrder.Operations.Abort();

                TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrder.Id} has been {response.PaymentOrder.State}";
                cartService.PaymentOrderLink = null;

                return RedirectToAction(nameof(Index), "Products");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Index), "Orders");
            }
        }


        [HttpGet]
        public async Task<ActionResult> PaymentOrderCancel(string paymentOrderId)
        {
            try
            {
                var paymentOrder = await swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));
                
                if (paymentOrder.Operations.Cancel != null)
                {
                    var cancelRequest = new SwedbankPay.Sdk.PaymentOrders.PaymentOrderCancelRequest(DateTime.Now.Ticks.ToString(), "Cancelling parts of the total amount");
                    var response = await paymentOrder.Operations.Cancel(cancelRequest);
                    TempData["CancelMessage"] = $"Payment has been cancelled: {response.Cancellation.Transaction.Id}";
                    cartService.PaymentOrderLink = null;
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation not available";
                }

                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }



        [HttpGet]
        public async Task<ActionResult> Cancel(string paymentId, PaymentInstrument instrument)
        {
            try
            {
                switch (instrument)
                {
                    case PaymentInstrument.CreditCard:
                        await PaymentHelper.CancelCreditCardPayment(paymentId, swedbankPayClient, TempData, cartService);
                        break;
                    case PaymentInstrument.Trustly:
                        await PaymentHelper.CancelTrustlyPayment(paymentId, swedbankPayClient, TempData, cartService);
                        break;
                }

                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }


        [HttpGet]
        public async Task<IActionResult> PaymentOrderCapture(string paymentOrderId)
        {
            try
            {
                var transActionRequestObject = await GetCaptureRequest("Capturing the authorized payment");
                var paymentOrder = await swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

                var response = await paymentOrder.Operations.Capture(transActionRequestObject);

                TempData["CaptureMessage"] =
                    $"{response.Capture.Id}, {response.Capture.State}, {response.Capture.Type}";

                cartService.PaymentOrderLink = null;

                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Capture(string paymentId, PaymentInstrument instrument)
        {
            try
            {
                var description = "Capturing the authorized payment";
                var transActionRequestObject = await GetCaptureRequest(description);

                switch (instrument)
                {
                    case PaymentInstrument.CreditCard:
                        var cardPayment = await swedbankPayClient.Payments.CardPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));

                        var order = await context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
                        var orderItems = order.Lines.ToOrderItems();

                        var captureRequest = new SwedbankPay.Sdk.PaymentInstruments.Card.CardPaymentCaptureRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                                                                                                                   new Amount(0),
                                                                                                                   orderItems.ToList(),
                                                                                                                   description,
                                                                                                                   DateTime.Now.Ticks.ToString());
                        var response = await cardPayment.Operations.Capture(captureRequest);
                        TempData["CaptureMessage"] = $"{response.Capture.Id}, {response.Capture.State}, {response.Capture.Type}";
                        break;
                }

                cartService.PaymentLink = null;
                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }


        [HttpPost]
        public void OnCompleted(string paymentLinkId)
        {
            if (cartService.CartLines != null && cartService.CartLines.Any())
            {
                var products = cartService.CartLines.Select(p => p.Product);
                context.Products.AttachRange(products);

                context.Orders.Add(new Order
                {
                    PaymentOrderLink = cartService.PaymentOrderLink != null ? new Uri(cartService.PaymentOrderLink, UriKind.RelativeOrAbsolute) : null,
                    PaymentLink = !string.IsNullOrWhiteSpace(paymentLinkId) ? new Uri(paymentLinkId, UriKind.RelativeOrAbsolute) : null,
                    Instrument = cartService.Instrument,
                    Lines = cartService.CartLines.ToList()
                });
                context.SaveChanges(true);
                cartService.Clear();
            }
        }

        [HttpGet]
        public async Task<IActionResult> PaymentOrderReversal(string paymentOrderId)
        {
            try
            {
                var transActionRequestObject = await GetReversalRequest("Reversing the capture amount");
                var paymentOrder = await swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

                var response = await paymentOrder.Operations.Reverse.Invoke(transActionRequestObject);

                TempData["ReversalMessage"] =
                    $"{response.Reversal.Transaction.Id}, {response.Reversal.Transaction.Type}, {response.Reversal.Transaction.State}";
                cartService.PaymentOrderLink = null;

                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Reversal(string paymentId, PaymentInstrument instrument)
        {
            try
            {
                var description = "Reversing the captured amount";
                IReversalResponse response = null;

                var order = await context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
                switch (instrument)
                {
                    case PaymentInstrument.Swish:
                        response = await PaymentHelper.ReverseSwishPayment(paymentId, order, description, swedbankPayClient);
                        break;
                    case PaymentInstrument.CreditCard:
                        response = await PaymentHelper.ReverseCreditCardPayment(paymentId, order, description, swedbankPayClient);
                        break;
                    case PaymentInstrument.Trustly:
                        response = await PaymentHelper.ReverseTrustlyPayment(paymentId, order, description, swedbankPayClient);
                        break;
                }

                TempData["ReversalMessage"] = $"{response.Reversal.Transaction.Id}, {response.Reversal.Transaction.Type}, {response.Reversal.Transaction.State}";
                cartService.PaymentOrderLink = null;

                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }


        private async Task<SwedbankPay.Sdk.PaymentOrders.PaymentOrderCaptureRequest> GetCaptureRequest(string description)
        {
            var order = await context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
            var orderItems = order.Lines.ToOrderItems();

            return new SwedbankPay.Sdk.PaymentOrders.PaymentOrderCaptureRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                                                                  new Amount(0), orderItems.ToList(), description, DateTime.Now.Ticks.ToString());
        }

        private async Task<SwedbankPay.Sdk.PaymentOrders.PaymentOrderReversalRequest> GetReversalRequest(string description)
        {
            var order = await context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
            var orderItems = order.Lines.ToOrderItems();

            return new SwedbankPay.Sdk.PaymentOrders.PaymentOrderReversalRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                                                                                 new Amount(0),
                                                                                 orderItems.ToList(),
                                                                                 description,
                                                                                 DateTime.Now.Ticks.ToString());
        }
    }
}