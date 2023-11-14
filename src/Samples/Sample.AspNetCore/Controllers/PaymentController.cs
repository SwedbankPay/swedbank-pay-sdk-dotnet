using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.JsonSerialization;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace Sample.AspNetCore.Controllers;

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
            var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute), PaymentOrderExpand.All);

            var response = await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("CanceledByUser"));

            TempData["PaymentOrderLink"] = response.PaymentOrder.Id.ToString();
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


    [HttpGet]
    public async Task<IActionResult> GetPaymentOrder(string paymentOrderId)
    {
        var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute), PaymentOrderExpand.All);
        return Json(paymentOrder, JsonSerialization.Settings);
    }

    [HttpGet]
    public async Task<IActionResult> PaymentOrderCancel(string paymentOrderId)
    {
        try
        {
            var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

            if (paymentOrder.Operations.Cancel != null)
            {
                var cancelRequest = new PaymentOrderCancelRequest("Cancelling parts of the total amount", _payeeInfoOptions.PayeeReference);
                var response = await paymentOrder.Operations.Cancel(cancelRequest);
                TempData["CancelMessage"] = $"Payment has been cancelled: {response.PaymentOrder.Cancelled.Id}";
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
    public async Task<IActionResult> PaymentOrderCapture(string paymentOrderId)
    {
        try
        {
            var transActionRequestObject = await GetCaptureRequest(paymentOrderId, "Capturing the authorized payment", DateTime.Now.Ticks.ToString());
            var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute));

            var response = await paymentOrder.Operations.Capture(transActionRequestObject);

            TempData["CaptureMessage"] = $"{response.PaymentOrder.FinancialTransactions.Id}, {response.PaymentOrder.Status}";
                
            this._cartService.PaymentOrderLink = null;

            return RedirectToAction("Details", "Orders");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
            return RedirectToAction("Details", "Orders");
        }
    }

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

    [HttpGet]
    public async Task<IActionResult> PaymentOrderReversal(string paymentOrderId)
    {
        try
        {
            var transActionRequestObject = await GetReversalRequest(paymentOrderId, "Reversing the capture amount");
            var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(new Uri(paymentOrderId, UriKind.RelativeOrAbsolute), PaymentOrderExpand.All);

            var response = await paymentOrder.Operations.Reverse(transActionRequestObject);
            var financialTransactionListItem = response.PaymentOrder.FinancialTransactions.FinancialTransactionsList.FirstOrDefault(x => x.Type == "Reversal");
            TempData["ReversalMessage"] = $"{response.PaymentOrder.FinancialTransactions.Id}, {response.PaymentOrder.Status}";
            _cartService.PaymentOrderLink = null;

            return RedirectToAction("Details", "Orders");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
            return RedirectToAction("Details", "Orders");
        }
    }


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

    private async Task<PaymentOrderCaptureRequest> GetCaptureRequest(string paymentOrderId, string description, string receiptReference)
    {
        var order = await _context.Orders.Where(x => x.PaymentOrderLink.ToString().Equals(paymentOrderId, StringComparison.InvariantCultureIgnoreCase))
            .Include(l => l.Lines)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync();
            
        var orderItems = order.Lines.ToOrderItems();

        var request = new PaymentOrderCaptureRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
            new Amount(0), description, DateTime.Now.Ticks.ToString(), receiptReference);
        foreach (var item in orderItems)
        {
            request.Transaction.OrderItems.Add(item);
        }

        return request;
    }

    private async Task<PaymentOrderReversalRequest> GetReversalRequest(string paymentOrderId, string description)
    {
        var order = await _context.Orders.Where(x => x.PaymentOrderLink.ToString().Equals(paymentOrderId, StringComparison.InvariantCultureIgnoreCase))
            .Include(l => l.Lines)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync();

        var orderItems = order.Lines.ToOrderItems();

        var request = new PaymentOrderReversalRequest(new Amount(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
            new Amount(0),
            description,
            DateTime.Now.Ticks.ToString());
        foreach (var item in orderItems)
        {
            request.Transaction.OrderItems.Add(item);
        }

        return request;
    }
}