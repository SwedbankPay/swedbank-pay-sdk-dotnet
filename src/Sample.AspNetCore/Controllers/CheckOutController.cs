using Sample.AspNetCore.Extensions;

namespace Sample.AspNetCore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Sample.AspNetCore.Models;
    using SwedbankPay.Sdk;
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;

    public class CheckOutController : Controller
    {
        private readonly PayeeInfo payeeInfoOptions;
        private readonly Cart cartService;
        private readonly SwedbankPayClient swedbankPayClient;

        public CheckOutController(IOptionsMonitor<PayeeInfo> payeeInfoOptionsAccessor,
            Cart cartService, SwedbankPayClient swedbankPayClient)
        {
            this.payeeInfoOptions = payeeInfoOptionsAccessor.CurrentValue;
            this.cartService = cartService;
            this.swedbankPayClient = swedbankPayClient;
        }
        
        public async Task<PaymentOrder> CreatePaymentOrder(string consumerProfileRef = null)
        {
            this.payeeInfoOptions.PayeeReference = DateTime.Now.Ticks.ToString();

            var totalAmount = this.cartService.CalculateTotal();
            var paymentOrderRequest = CreatePaymentOrderRequest(totalAmount, 0); //TODO Correct VatAmount
            
            paymentOrderRequest.OrderItems = new List<OrderItem>();
            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
            {
                paymentOrderRequest.Payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };
            }
            
            var orderItems = this.cartService.CartLines.ToOrderItems();

            paymentOrderRequest.OrderItems = orderItems.ToList();
            
            var paymentOrder = await this.swedbankPayClient.PaymentOrder.Create(paymentOrderRequest);
            
            this.cartService.PaymentOrderLink = paymentOrder.PaymentOrderResponse.Id;
            this.cartService.Update();
            
            
            return paymentOrder;
        }

        [HttpPost]
        public async Task<JsonResult> GetViewPaymentOrderHref(string consumerProfileRef = null)
        {
            var paymentOrder = await CreatePaymentOrder(consumerProfileRef);

            return Json (paymentOrder.Operations.View.Href);
        }

        public async Task<IActionResult> LoadPaymentMenu()
        {
            var response = await CreatePaymentOrder();
            
            var jsSource = response.Operations.View.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = "sv-SE",
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
            };

            return View("Checkout", swedBankPaySource);
        }

        private PaymentOrderRequest CreatePaymentOrderRequest(decimal amount, decimal vatAmount)
        {
            var paymentOrderRequest = new PaymentOrderRequest
            {
                Amount = Amount.FromDecimal(amount),
                VatAmount = Amount.FromDecimal(vatAmount),
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
            var initiateConsumerRequest = new ConsumersRequest { ConsumerCountryCode = CountryCode.SE };
            var response = await this.swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
            var jsSource = response.Operations.ViewConsumerIdentification?.Href;
            
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