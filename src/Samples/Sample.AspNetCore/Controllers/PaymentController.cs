using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using System;
using System.Linq;
using System.Threading.Tasks;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace Sample.AspNetCore.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Cart _cartService;
        private readonly StoreDbContext _context;
        private readonly PayeeInfoConfig _payeeInfoOptions;
        private readonly ISwedbankPayClient _swedbankPayClient;
        private readonly UrlsOptions _urls;


        public PaymentController(
            IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor, 
            Cart cart, 
            StoreDbContext dbContext, 
            ISwedbankPayClient payClient,
            IOptionsSnapshot<UrlsOptions> urlsAccessor)
        {
            _payeeInfoOptions = payeeInfoOptionsAccessor.Value;
            _cartService = cart;
            _context = dbContext;
            _swedbankPayClient = payClient;
            _urls = urlsAccessor.Value;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AbortPaymentOrder(string paymentOrderId)
        {
            try
            {
                var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

                var response = await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("CanceledByUser"));

                TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrder.Id} has been {response.PaymentOrder.Status}";
                _cartService.PaymentOrderLink = null;
                _cartService.Update();

                return RedirectToAction(nameof(Index), "Products");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Index), "Orders");
            }
        }


        // [HttpGet]
        // public async Task<ActionResult> PaymentOrderCancel(string paymentOrderId)
        // {
        //     try
        //     {
        //         var paymentOrder = await this._swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));
        //         
        //         if (paymentOrder.Operations.Cancel != null)
        //         {
        //             var cancelRequest = new SwedbankPay.Sdk.PaymentOrders.PaymentOrderCancelRequest(DateTime.Now.Ticks.ToString(), "Cancelling parts of the total amount");
        //             var response = await paymentOrder.Operations.Cancel(cancelRequest);
        //             TempData["CancelMessage"] = $"Payment has been cancelled: {response.Cancellation.Transaction.Id}";
        //         }
        //         else
        //         {
        //             TempData["ErrorMessage"] = "Operation not available";
        //         }
        //
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }



        // [HttpGet]
        // public async Task<ActionResult> Cancel(string paymentId, PaymentInstrument instrument)
        // {
        //     try
        //     {
        //         switch (instrument)
        //         {
        //             case PaymentInstrument.CreditCard:
        //                 await PaymentHelper.CancelCreditCardPayment(paymentId, this._swedbankPayClient, TempData, this._cartService);
        //                 break;
        //             case PaymentInstrument.Trustly:
        //                 await PaymentHelper.CancelTrustlyPayment(paymentId, this._swedbankPayClient, TempData, this._cartService);
        //                 break;
        //             case PaymentInstrument.Invoice:
        //                 await PaymentHelper.CancelInvoicePayment(paymentId, this._payeeInfoOptions.PayeeReference, this._swedbankPayClient, TempData, this._cartService);
        //                 break;
        //         }
        //
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }


        // [HttpGet]
        // public async Task<IActionResult> PaymentOrderCapture(string paymentOrderId)
        // {
        //     try
        //     {
        //         var transActionRequestObject = await GetCaptureRequest("Capturing the authorized payment");
        //         var paymentOrder = await this._swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));
        //
        //         var response = await paymentOrder.Operations.Capture(transActionRequestObject);
        //
        //         TempData["CaptureMessage"] =
        //             $"{response.Capture.Transaction.Id}, {response.Capture.Transaction.State}, {response.Capture.Transaction.Type}";
        //
        //         this._cartService.PaymentOrderLink = null;
        //
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }

        // [HttpGet]
        // public async Task<IActionResult> Recurring(string paymentId, PaymentInstrument instrument)
        // {
        //     try
        //     {
        //         var description = "Recurring the authorized payment";
        //         
        //         switch (instrument)
        //         {
        //             case PaymentInstrument.CreditCard:
        //                 var cardPayment = await this._swedbankPayClient.Payments.CardPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));
        //
        //                 var recurringRequest = await GetRecurringRequest(description, cardPayment.Payment.RecurrenceToken);
        //
        //                 var response = await this._swedbankPayClient.Payments.CardPayments.Create(recurringRequest, PaymentExpand.All);
        //                 var transaction = response.Payment.Transactions.TransactionList.LastOrDefault();
        //                 TempData["CaptureMessage"] = $"{transaction.Id}, {transaction.State}, {transaction.Type}";
        //                 break;
        //         }
        //
        //         this._cartService.PaymentLink = null;
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }


        // [HttpGet]
        // public async Task<IActionResult> Capture(string paymentId, PaymentInstrument instrument)
        // {
        //     try
        //     {
        //         var description = "Capturing the authorized payment";
        //         var transActionRequestObject = await GetCaptureRequest(description);
        //
        //         switch (instrument)
        //         {
        //             case PaymentInstrument.CreditCard:
        //                 var cardPayment = await this._swedbankPayClient.Payments.CardPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));
        //
        //                 var order = await this._context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
        //                 var orderItems = order.Lines.ToOrderItems();
        //
        //                 var captureRequest = new SwedbankPay.Sdk.PaymentInstruments.Card.CardPaymentCaptureRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
        //                                                                                                            new Amount(0),
        //                                                                                                            description,
        //                                                                                                            DateTime.Now.Ticks.ToString());
        //                 foreach (var item in orderItems)
        //                 {
        //                     captureRequest.Transaction.OrderItems.Add(item);
        //                 }
        //
        //                 var response = await cardPayment.Operations.Capture(captureRequest);
        //                 TempData["CaptureMessage"] = $"{response.Capture.Transaction.Id}, {response.Capture.Transaction.State}, {response.Capture.Transaction.Type}";
        //                 break;
        //         }
        //
        //         this._cartService.PaymentLink = null;
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }


        [HttpPost]
        public void OnCompleted(string paymentLinkId)
        {
            if (_cartService.CartLines != null && _cartService.CartLines.Any())
            {
                var products = _cartService.CartLines.Select(p => p.Product);
                _context.Products.AttachRange(products);

                _context.Orders.Add(new Order
                {
                    PaymentOrderLink = _cartService.PaymentOrderLink != null ? new Uri(_cartService.PaymentOrderLink, UriKind.RelativeOrAbsolute) : null,
                    PaymentLink = !string.IsNullOrWhiteSpace(paymentLinkId) ? new Uri(paymentLinkId, UriKind.RelativeOrAbsolute) : null,
                    Lines = _cartService.CartLines.ToList()
                });
                _context.SaveChanges(true);
                _cartService.Clear();
            }
        }

        // [HttpGet]
        // public async Task<IActionResult> PaymentOrderReversal(string paymentOrderId)
        // {
        //     try
        //     {
        //         var transActionRequestObject = await GetReversalRequest("Reversing the capture amount");
        //         var paymentOrder = await this._swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));
        //
        //         var response = await paymentOrder.Operations.Reverse.Invoke(transActionRequestObject);
        //
        //         TempData["ReversalMessage"] =
        //             $"{response.Reversal.Transaction.Id}, {response.Reversal.Transaction.Type}, {response.Reversal.Transaction.State}";
        //         this._cartService.PaymentOrderLink = null;
        //
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }


        // [HttpGet]
        // public async Task<IActionResult> Reversal(string paymentId, PaymentInstrument instrument)
        // {
        //     try
        //     {
        //         var description = "Reversing the captured amount";
        //         IReversalResponse response = null;
        //
        //         var order = await this._context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
        //         switch (instrument)
        //         {
        //             case PaymentInstrument.Swish:
        //                 response = await PaymentHelper.ReverseSwishPayment(paymentId, order, description, this._swedbankPayClient);
        //                 break;
        //             case PaymentInstrument.CreditCard:
        //                 response = await PaymentHelper.ReverseCreditCardPayment(paymentId, order, description, this._swedbankPayClient);
        //                 break;
        //             case PaymentInstrument.Trustly:
        //                 response = await PaymentHelper.ReverseTrustlyPayment(paymentId, order, description, this._swedbankPayClient);
        //                 break;
        //         }
        //
        //         TempData["ReversalMessage"] = $"{response.Reversal.Transaction.Id}, {response.Reversal.Transaction.Type}, {response.Reversal.Transaction.State}";
        //         this._cartService.PaymentOrderLink = null;
        //
        //         return RedirectToAction("Details", "Orders");
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
        //         return RedirectToAction("Details", "Orders");
        //     }
        // }


        // private async Task<SwedbankPay.Sdk.PaymentInstruments.Card.CardPaymentRecurRequest> GetRecurringRequest(string description, string reccurenceToken)
        // {
        //     var order = await this._context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
        //     
        //     var request = new SwedbankPay.Sdk.PaymentInstruments.Card.CardPaymentRecurRequest(PaymentIntent.AutoCapture, reccurenceToken, new Currency("SEK"), new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
        //                                                                                new Amount(0), description, "useragent", new Language("sv-SE"),
        //                                                                                new Urls(this._urls.HostUrls.ToList(), this._urls.CompleteUrl,
        //                                                                                    this._urls.TermsOfServiceUrl)
        //                                                                                {
        //                                                                                    CancelUrl = this._urls.CancelUrl,
        //                                                                                    PaymentUrl = this._urls.PaymentUrl,
        //                                                                                    CallbackUrl = this._urls.CallbackUrl,
        //                                                                                    LogoUrl = this._urls.LogoUrl
        //                                                                                }, new PayeeInfo(this._payeeInfoOptions.PayeeId, this._payeeInfoOptions.PayeeReference));
        //     return request;
        // }

        // private async Task<SwedbankPay.Sdk.PaymentOrders.PaymentOrderCaptureRequest> GetCaptureRequest(string description)
        // {
        //     var order = await this._context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
        //     var orderItems = order.Lines.ToOrderItems();
        //
        //     var request = new SwedbankPay.Sdk.PaymentOrders.PaymentOrderCaptureRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
        //                                                           new Amount(0), description, DateTime.Now.Ticks.ToString());
        //     foreach (var item in orderItems)
        //     {
        //         request.Transaction.OrderItems.Add(item);
        //     }
        //
        //     return request;
        // }
        //
        // private async Task<SwedbankPay.Sdk.PaymentOrders.PaymentOrderReversalRequest> GetReversalRequest(string description)
        // {
        //     var order = await this._context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
        //     var orderItems = order.Lines.ToOrderItems();
        //
        //     var request = new SwedbankPay.Sdk.PaymentOrders.PaymentOrderReversalRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
        //                                                                          new Amount(0),
        //                                                                          description,
        //                                                                          DateTime.Now.Ticks.ToString());
        //     foreach (var item in orderItems)
        //     {
        //         request.Transaction.OrderItems.Add(item);
        //     }
        //
        //     return request;
        // }
    }
}