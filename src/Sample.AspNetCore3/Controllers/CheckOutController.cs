using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sample.AspNetCore3.Constants;
using Sample.AspNetCore3.Models;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Consumers;
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
        
        //public async Task<PaymentOrderResponseContainer> CreatePaymentOrder()
        //{
        //    var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);

        //    _payeeInfoOptions.PayeeReference = DateTime.Now.Ticks.ToString();
           
        //    var totalAmount = _cartService.CalculateTotal() * 100;
        //    var paymentOrderRequest = CreatePaymentOrderRequestContainer(totalAmount, 0); //TODO Correct VatAmount

        //    paymentOrderRequest.Paymentorder.OrderItems = new List<OrderItem>();
        //    var orderItems = _cartService.CartLines.Select(line => new OrderItem
        //    {
        //        Amount = (int?) line.CalculateTotal() * 100,
        //        Quantity = line.Quantity,
        //        Reference = line.Product.Reference,
        //        Name = line.Product.Name,
        //        Type = line.Product.Type,
        //        Class = line.Product.Class,
        //        ItemUrl = "https://example.com/products/123",
        //        ImageUrl = "https://example.com/products/123.jpg",
        //        Description = "Product 1 description",
        //        QuantityUnit = "pcs",
        //        UnitPrice = line.Product.Price * 100,
        //        VatPercent = 0, //TODO Correct VatPercent
        //        VatAmount = 0 //TODO Correct VatAmount
        //    });

        //    var response = await swedbankPayClient.PaymentOrders.CreatePaymentOrder(paymentOrderRequest);
        //    return response;
        //}
        [HttpPost]
        public async Task<JsonResult> CreatePaymentOrder(string consumerProfileRef = null)
        {
            var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);

            _payeeInfoOptions.PayeeReference = DateTime.Now.Ticks.ToString();

            var totalAmount = _cartService.CalculateTotal() * 100;
            var paymentOrderRequest = CreatePaymentOrderRequestContainer(totalAmount, 0); //TODO Correct VatAmount

            paymentOrderRequest.Paymentorder.OrderItems = new List<OrderItem>();
            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
            {
                paymentOrderRequest.Paymentorder.Payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };
            }
            var orderItems = _cartService.CartLines.Select(line => new OrderItem
            {
                Amount = (int?)line.CalculateTotal() * 100,
                Quantity = line.Quantity,
                Reference = line.Product.Reference,
                Name = line.Product.Name,
                Type = line.Product.Type,
                Class = line.Product.Class,
                ItemUrl = "https://example.com/products/123",
                ImageUrl = "https://example.com/products/123.jpg",
                Description = "Product 1 description",
                QuantityUnit = "pcs",
                UnitPrice = line.Product.Price * 100,
                VatPercent = 0, //TODO Correct VatPercent
                VatAmount = 0, //TODO Correct VatAmount
            }).ToList();
            paymentOrderRequest.Paymentorder.OrderItems = orderItems;

            var response = await swedbankPayClient.PaymentOrders.CreatePaymentOrder(paymentOrderRequest);
            return new JsonResult(response);
        }

        public async Task<IActionResult> LoadPaymentMenu()
        {
            var responseJsonResult = await CreatePaymentOrder();
            
            var response = responseJsonResult.Value as PaymentOrderResponseContainer;

            var jsSource = response.Operations.FirstOrDefault(x => x.Rel == Operations.ViewPaymentOrder)?.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = "sv-SE",
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations.FirstOrDefault(x => x.Rel == "update-paymentorder-abort")?.Href
            };

            return View("Checkout", swedBankPaySource);
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
                        CompleteUrl = "https://localhost:44344/Checkout/Thankyou",
                        LogoUrl = null,
                        HostUrls = new List<string> { { "https://payex.eu.ngrok.io" } }
                    },
                    PayeeInfo = _payeeInfoOptions
                }
            };
            return paymentOrderRequestContainer;
        }

        public async Task<IActionResult> InitiateConsumerSession()
        {
            var initiateConsumerRequest = new ConsumersRequest();
            initiateConsumerRequest.ConsumerCountryCode = "SE";

            var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);
            var response = await swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
            var jsSource = response.Operations.FirstOrDefault(x => x.Rel == Operations.ViewConsumerIdentification)?.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = "sv-SE",
                UseAnonymousCheckout = false
            };
            return View("Checkout", swedBankPaySource);
        }

        public ViewResult Thankyou()
        {

            _cartService.Clear();
            return View();
        }



    }
}