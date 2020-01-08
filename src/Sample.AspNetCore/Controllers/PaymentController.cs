using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Transactions;

namespace Sample.AspNetCore.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Cart cartService;
        private readonly StoreDbContext context;
        private readonly SwedbankPayClient swedbankPayClient;


        public PaymentController(Cart cartService, StoreDbContext context, SwedbankPayClient swedbankPayClient)
        {
            this.cartService = cartService;
            this.context = context;
            this.swedbankPayClient = swedbankPayClient;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AbortPaymentOrder(string paymentOrderId)
        {
            try
            {
                var paymentOrder = await this.swedbankPayClient.PaymentOrder.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

                var response = await paymentOrder.Operations.Abort.Execute();

                TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrderResponse.Id} has been {response.PaymentOrderResponse.State}";
                this.cartService.PaymentOrderLink = null;

                return RedirectToAction(nameof(Index), "Products");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Index), "Orders");
            }
        }


        [HttpGet]
        public async Task<ActionResult> CancelPayment(string paymentOrderId)
        {
            try
            {
                var transactionRequestObject = new TransactionRequest(null,"Cancelling parts of the total amount", null, DateTime.Now.Ticks.ToString(), 0);

                var paymentOrder = await this.swedbankPayClient.PaymentOrder.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));
                var container = new TransactionRequestContainer<TransactionRequest>(transactionRequestObject);
                if (paymentOrder.Operations.Cancel != null)
                {
                    var response = await paymentOrder.Operations.Cancel.Execute(container);
                    TempData["CancelMessage"] = $"Payment has been cancelled: {response.Cancellation.Transaction.Id}";
                    this.cartService.PaymentOrderLink = null;
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
        public async Task<IActionResult> CapturePayment(string paymentOrderId)
        {
            try
            {
                var transActionRequestObject = await GetTransactionRequest("Capturing the authorized payment");
                var paymentOrder = await this.swedbankPayClient.PaymentOrder.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

                var container = new TransactionRequestContainer<TransactionRequest>(transActionRequestObject);
                var response = await paymentOrder.Operations.Capture.Execute(container);

                TempData["CaptureMessage"] =
                    $"{response.Capture.Transaction.Id}, {response.Capture.Transaction.State}, {response.Capture.Transaction.Type}"; 

                this.cartService.PaymentOrderLink = null;

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
            var products = this.cartService.CartLines.Select(p => p.Product);
            this.context.Products.AttachRange(products);

            this.context.Orders.Add(new Order
            {
                PaymentOrderLink = this.cartService.PaymentOrderLink,
                PaymentLink = paymentLinkId,
                Lines = this.cartService.CartLines.ToList()
            });
            this.context.SaveChanges(true);
        }


        [HttpGet]
        public async Task<IActionResult> ReversalPayment(string paymentOrderId)
        {
            try
            {
                var transActionRequestObject = await GetTransactionRequest("Reversing the capture amount");
                var paymentOrder = await this.swedbankPayClient.PaymentOrder.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));
                var container = new TransactionRequestContainer<TransactionRequest>(transActionRequestObject);
                var response = await paymentOrder.Operations.Reversal.Execute(container);

                TempData["ReversalMessage"] =
                    $"{response.Reversal.Transaction.Id}, {response.Reversal.Transaction.Type}, {response.Reversal.Transaction.State}";
                this.cartService.PaymentOrderLink = null;

                return RedirectToAction("Details", "Orders");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction("Details", "Orders");
            }
        }


        private async Task<TransactionRequest> GetTransactionRequest(string description)
        {
            var order = await this.context.Orders.Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefaultAsync();
            var orderItems = order.Lines.ToOrderItems();

            var transActionRequestObject = new TransactionRequest(Amount.FromDecimal(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                                                                  description,
                                                                  orderItems.ToList(),
                                                                  DateTime.Now.Ticks.ToString(),
                                                                  0
            );

            return transActionRequestObject;
        }
    }
}