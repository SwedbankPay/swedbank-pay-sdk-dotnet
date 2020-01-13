using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly Cart cartService;
        private readonly PayeeInfoConfig payeeInfoOptions;
        private readonly SwedbankPayClient swedbankPayClient;
        private readonly UrlsOptions urls;


        public CheckOutController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
                                  IOptionsSnapshot<UrlsOptions> urlsAccessor,
                                  Cart cartService,
                                  SwedbankPayClient swedbankPayClient)
        {
            this.payeeInfoOptions = payeeInfoOptionsAccessor.Value;
            this.urls = urlsAccessor.Value;
            this.cartService = cartService;
            this.swedbankPayClient = swedbankPayClient;
        }


        public async Task<PaymentOrder> CreatePaymentOrder(string consumerProfileRef = null)
        {
            var totalAmount = this.cartService.CalculateTotal();
            Payer payer = null;

            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
                payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };

            var orderItems = this.cartService.CartLines.ToOrderItems();
            var paymentOrderItems = orderItems?.ToList();
            try
            {
                var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new CurrencyCode("SEK"),
                                                                  Amount.FromDecimal(totalAmount),
                                                                  Amount.FromDecimal(0), "Test description", "useragent",
                                                                  new Language(CultureInfo.CreateSpecificCulture("sv-SE")),
                                                                  false,
                                                                  new Urls(this.urls.HostUrls, this.urls.CompleteUrl,
                                                                           this.urls.TermsOfServiceUrl, this.urls.CancelUrl,
                                                                           this.urls.PaymentUrl, this.urls.CallbackUrl, this.urls.LogoUrl),
                                                                  new PayeeInfo(this.payeeInfoOptions.PayeeId,
                                                                                this.payeeInfoOptions.PayeeReference), payer,
                                                                  paymentOrderItems);
                var paymentOrder = await this.swedbankPayClient.PaymentOrder.Create(paymentOrderRequest);

                this.cartService.PaymentOrderLink = paymentOrder.PaymentOrderResponse.Id.OriginalString;
                this.cartService.Update();

                return paymentOrder;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return null;
            }
        }


        [HttpPost]
        public async Task<JsonResult> GetViewPaymentOrderHref(string consumerProfileRef = null)
        {
            var paymentOrder = await CreatePaymentOrder(consumerProfileRef);

            return Json(paymentOrder.Operations.View.Href);
        }


        public async Task<IActionResult> InitiateConsumerSession()
        {
            var initiateConsumerRequest = new ConsumersRequest(shippingAddressRestrictedToCountryCodes: new List<string>{"SE"}, language: new Language(new CultureInfo("sv-SE")));
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


        public ViewResult Thankyou()
        {
            this.cartService.Clear();
            return View();
        }
    }
}