using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.AspNetCore3.Constants;
using Sample.AspNetCore3.Models;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore3.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly SwedbankPayOptions _swedbankPayOptions;

        public const string CartSessionKey = "_Cart";
        private readonly PayeeInfo _payeeInfoOptions;
        private Cart _cartService;

        public CheckOutController(IOptionsMonitor<SwedbankPayOptions> swedbankPayOptionsAccessor, IOptionsMonitor<PayeeInfo> payeeInfoOptionsAccessor, Cart cartService)
        {
            _swedbankPayOptions = swedbankPayOptionsAccessor.CurrentValue;

            _payeeInfoOptions = payeeInfoOptionsAccessor.CurrentValue;
            _cartService = cartService;
        }

        public async Task<ActionResult> Checkout()
        {


            var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);
            
            _payeeInfoOptions.PayeeReference = DateTime.Now.Ticks.ToString();
            //_payeeInfoOptions.PayeeReference = "34235435345345";
            var totalAmount = _cartService.CalculateTotal()*100;
            var paymentOrderRequest = CreatePaymentOrderRequestContainer(totalAmount, 0); //TODO Correct VatAmount

            paymentOrderRequest.Paymentorder.OrderItems = new List<OrderItem>();
            var orderItems = _cartService.CartLines.Select(line => new OrderItem
            {
                Amount = (int?)line.CalculateTotal()*100,
                Quantity = line.Quantity,
                Reference = line.Product.Reference,
                Name = line.Product.Name,
                Type = line.Product.Type,
                Class = line.Product.Class,
                ItemUrl = "https://example.com/products/123",
                ImageUrl = "https://example.com/products/123.jpg",
                Description = "Product 1 description",
                QuantityUnit = "pcs",
                UnitPrice = line.Product.Price*100,
                VatPercent = 0, //TODO Correct VatPercent
                VatAmount = 0 //TODO Correct VatAmount

            });

            var response = await swedbankPayClient.PaymentOrders.CreatePaymentOrder(paymentOrderRequest);
            var jsSource = response.Operations.FirstOrDefault(x => x.Rel == Operations.ViewPaymentOrder)?.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource, 
                Culture = "sv-SE", 
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations.FirstOrDefault(x => x.Rel == "update-paymentorder-abort")?.Href
            };

            return View(swedBankPaySource);
        }
        private PaymentOrderRequestContainer CreatePaymentOrderRequestContainer(long amount, long vatAmount)
        {
            var paymentOrderRequestContainer = new PaymentOrderRequestContainer
            {
                Paymentorder = new PaymentOrderRequest
                {
                    Amount = amount,
                    VatAmount = vatAmount,
                    Currency = "SEK",
                    Description = "Description",
                    Language = "sv-SE",
                    UserAgent = "useragent",
                    Urls = new Urls
                    {
                        TermsOfServiceUrl = null,
                        CallbackUrl = null,
                        CancelUrl = "https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}",
                        CompleteUrl = "https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}",
                        LogoUrl = null,
                        HostUrls = new List<string> { { "https://payex.eu.ngrok.io" } }
                    },
                    PayeeInfo = _payeeInfoOptions
                }
            };
            return paymentOrderRequestContainer;
        }

        

    }
}