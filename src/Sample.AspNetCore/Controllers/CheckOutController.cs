namespace Sample.AspNetCore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Sample.AspNetCore.Constants;
    using Sample.AspNetCore.Models;
    using SwedbankPay.Sdk;
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;

    public class CheckOutController : Controller
    {
        public const string CartSessionKey = "_Cart";
        private readonly PayeeInfo payeeInfoOptions;
        private Cart cartService;
        private readonly SwedbankPayClient swedbankPayClient;

        public CheckOutController(IOptionsMonitor<PayeeInfo> payeeInfoOptionsAccessor,
            Cart cartService, SwedbankPayClient swedbankPayClient)
        {
            this.payeeInfoOptions = payeeInfoOptionsAccessor.CurrentValue;
            this.cartService = cartService;
            this.swedbankPayClient = swedbankPayClient;
        }
        
        [HttpPost]
        public async Task<JsonResult> CreatePaymentOrder(string consumerProfileRef = null)
        {
            this.payeeInfoOptions.PayeeReference = DateTime.Now.Ticks.ToString();

            var totalAmount = this.cartService.CalculateTotal() * 100;
            var paymentOrderRequest = CreatePaymentOrderRequest(totalAmount, 0); //TODO Correct VatAmount
            
            paymentOrderRequest.OrderItems = new List<OrderItem>();
            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
            {
                paymentOrderRequest.Payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };
            }
            var orderItems = this.cartService.CartLines.Select(line => new OrderItem
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
            paymentOrderRequest.OrderItems = orderItems;

            var response = await this.swedbankPayClient.PaymentOrders.CreatePaymentOrder(paymentOrderRequest);
            this.cartService.PaymentOrderLink = response.PaymentOrder.Id;
            this.cartService.Update();
            return new JsonResult(response);
        }

        public async Task<IActionResult> LoadPaymentMenu()
        {
            var responseJsonResult = await CreatePaymentOrder();

            var response = responseJsonResult.Value as PaymentOrderResponseContainer;

            var jsSource = response.Operations.FirstOrDefault(x => x.Rel == PaymentOrderResourceOperations.ViewPaymentOrder)?.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = "sv-SE",
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations.FirstOrDefault(x => x.Rel == "update-paymentorder-abort")?.Href
            };

            return View("Checkout", swedBankPaySource);
        }

        private PaymentOrderRequest CreatePaymentOrderRequest(long amount, long vatAmount)
        {
            var paymentOrderRequest = new PaymentOrderRequest
            {
                Amount = amount,
                VatAmount = vatAmount,
                Currency = new CurrencyCode("SEK"),
                Description = "Description",
                Language = new Language("sv-SE"),
                UserAgent = "useragent",
                PayeeInfo = this.payeeInfoOptions
            };
            return paymentOrderRequest;
        }

        public async Task<IActionResult> InitiateConsumerSession()
        {
            var initiateConsumerRequest = new ConsumersRequest();
            initiateConsumerRequest.ConsumerCountryCode = CountryCode.SE;
           
            var response = await this.swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
            var jsSource = response.Operations.FirstOrDefault(x => x.Rel == ConsumerResourceOperations.ViewConsumerIdentification)?.Href;

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

            this.cartService.Clear();
            return View();
        }



    }
}