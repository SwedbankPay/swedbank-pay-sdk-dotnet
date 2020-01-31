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
using Sample.AspNetCore.Models.ViewModels;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Swish;

using Payment = SwedbankPay.Sdk.Payments.Card.Payment;
using PaymentRequest = SwedbankPay.Sdk.Payments.Card.PaymentRequest;

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
            payeeInfoOptions = payeeInfoOptionsAccessor.Value;
            urls = urlsAccessor.Value;
            this.cartService = cartService;
            this.swedbankPayClient = swedbankPayClient;
        }


        public async Task<PaymentOrder> CreatePaymentOrder(string consumerProfileRef = null)
        {
            var totalAmount = cartService.CalculateTotal();
            Payer payer = null;

            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
                payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };

            var orderItems = cartService.CartLines.ToOrderItems();
            var paymentOrderItems = orderItems?.ToList();
            try
            {
                var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new CurrencyCode("SEK"),
                                                                  Amount.FromDecimal(totalAmount),
                                                                  Amount.FromDecimal(0), "Test description", "useragent",
                                                                  CultureInfo.CreateSpecificCulture("sv-SE"),
                                                                  false,
                                                                  new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                           urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                           urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                  new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                payeeInfoOptions.PayeeReference), payer,
                                                                  paymentOrderItems);
                var paymentOrder = await swedbankPayClient.PaymentOrder.Create(paymentOrderRequest);

                cartService.PaymentOrderLink = paymentOrder.PaymentOrderResponse.Id.OriginalString;
                cartService.PaymentLink = null;
                cartService.Update();

                return paymentOrder;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return null;
            }
        }

        public async Task<Payment> CreateCardPayment()
        {
            var totalAmount = cartService.CalculateTotal();
            var vatAmount = Amount.FromDecimal(0);
            try
            {
                var cardRequest = new PaymentRequest(Operation.Purchase, Intent.Authorization, new CurrencyCode("SEK"),
                                                                                   new List<Price>
                                                                                   {
                                                                                       new Price(Amount.FromDecimal(totalAmount),
                                                                                                 PriceType.CreditCard, vatAmount)
                                                                                   },
                                                                                   "Test Purchase", payeeInfoOptions.PayeeReference,
                                                                                   CultureInfo.GetCultureInfo("sv-SE"),
                                                                                   new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                                            urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                                            urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                                   new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                                 payeeInfoOptions.PayeeReference));

                Payment cardPayment = await swedbankPayClient.Payment.CreateCreditCardPayment(cardRequest);
                cartService.PaymentLink = cardPayment.PaymentResponse.Id.OriginalString;
                cartService.Instrument = Instrument.CreditCard;
                cartService.PaymentOrderLink = null;
                cartService.Update();
                return cardPayment;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return null;
            }
        }

        public async Task<SwedbankPay.Sdk.Payments.Swish.Payment> CreateSwishPayment()
        {
            var totalAmount = cartService.CalculateTotal();
            var vatAmount = Amount.FromDecimal(0);
            try
            {
                var swishRequest = new SwedbankPay.Sdk.Payments.Swish.PaymentRequest(new CurrencyCode("SEK"),
                                                                                     new List<Price>
                                                                                     {
                                                                                         new Price(Amount.FromDecimal(totalAmount),
                                                                                                   PriceType.Swish, vatAmount)
                                                                                     },
                                                                                     "Test Purchase", payeeInfoOptions.PayeeReference, "useragent", CultureInfo.GetCultureInfo("sv-SE"),
                                                                                     new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                                              urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                                              urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                                     new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                                   payeeInfoOptions.PayeeReference), new PrefillInfo(new Msisdn("+46739000001")), new SwishRequest());
                SwedbankPay.Sdk.Payments.Swish.Payment swishPayment = await swedbankPayClient.Payment.CreateSwishPayment(swishRequest);
                cartService.PaymentLink = swishPayment.PaymentResponse.Id.OriginalString;
                cartService.Instrument = Instrument.Swish;
                cartService.PaymentOrderLink = null;
                cartService.Update();

                return swishPayment;
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
            var initiateConsumerRequest = new ConsumersRequest(shippingAddressRestrictedToCountryCodes: new List<RegionInfo>{new RegionInfo("SE")}, language: new Language("sv-SE"));
            var response = await swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
            var jsSource = response.Operations.ViewConsumerIdentification?.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = CultureInfo.GetCultureInfo("sv-SE"),
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
                Culture = CultureInfo.GetCultureInfo("sv-SE"),
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
            };

            return View("Checkout", swedBankPaySource);
        }

        public IActionResult LoadCardPaymentMenu()
        {
            return View("Payment");
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    var order = await this.context.Orders
        //        .FirstOrDefaultAsync();
        //    if (order == null)
        //        return NotFound();

        //    var paymentOrder = await this.swedbankPayClient.PaymentOrder.Get(new Uri(order.PaymentOrderLink, UriKind.RelativeOrAbsolute));

        //    var paymentOrderOperations = paymentOrder.Operations.Where(r => r.Key.Value.Contains("paymentorder")).Select(x => x.Value);

        //    var operations = new OperationList(paymentOrderOperations);

        //    return View(new OrderViewModel
        //    {
        //        Order = order,
        //        OperationList = operations
        //    });
        //}

        public async Task<IActionResult> LoadSwishPaymentMenu()
        {
            var response = await CreateSwishPayment();

            var jsSource = response.Operations.ViewSales.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = CultureInfo.GetCultureInfo("sv-SE"),
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
            };

            return View("Checkout", swedBankPaySource);
        }

        [HttpPost]
        public async Task<JsonResult> GetPaymentJsSource(Instrument instrument)
        {
            switch (instrument)
            {
                case Instrument.CreditCard:
                    var cardPayment = await CreateCardPayment();
                    return new JsonResult(cardPayment.Operations.ViewAuthorization.Href);
                    
                case Instrument.Swish:
                    var swishPayment = await CreateSwishPayment();
                    return new JsonResult(swishPayment.Operations.ViewSales.Href);
                default :
                    return null;
            }
        }
 

        public ViewResult Thankyou()
        {
            cartService.Clear();
            return View();
        }
    }
}