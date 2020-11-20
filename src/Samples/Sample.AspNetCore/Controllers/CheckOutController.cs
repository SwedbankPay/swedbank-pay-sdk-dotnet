using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Sample.AspNetCore.Data;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Swish;

namespace Sample.AspNetCore.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly Cart cartService;
        private readonly StoreDbContext context;
        private readonly PayeeInfoConfig payeeInfoOptions;
        private readonly ISwedbankPayClient swedbankPayClient;
        private readonly UrlsOptions urls;


        public CheckOutController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
                                  IOptionsSnapshot<UrlsOptions> urlsAccessor,
                                  Cart cart,
                                  StoreDbContext storeDbContext,
                                  ISwedbankPayClient payClient)
        {
            payeeInfoOptions = payeeInfoOptionsAccessor.Value;
            urls = urlsAccessor.Value;
            cartService = cart;
            context = storeDbContext;
            swedbankPayClient = payClient;
        }


        public async Task<IPaymentOrderResponse> CreatePaymentOrder(string consumerProfileRef = null)
        {
            var totalAmount = cartService.CalculateTotal();
            Payer payer = null;

            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
            {
                payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };
            }

            var orderItems = cartService.CartLines.ToOrderItems();
            var paymentOrderItems = orderItems?.ToList();
            try
            {
                var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new Currency("SEK"),
                                                                  new Amount(totalAmount),
                                                                  new Amount(0), "Test description", "useragent",
                                                                  new Language("sv-SE"),
                                                                  false,
                                                                  new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                           urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                           urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                  new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                payeeInfoOptions.PayeeReference), payer,
                                                                  paymentOrderItems);
                var paymentOrder = await swedbankPayClient.PaymentOrders.Create(paymentOrderRequest);

                cartService.PaymentOrderLink = paymentOrder.PaymentOrder.Id.OriginalString;
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

        public async Task<ICardPaymentResponse> CreateCardPayment()
        {
            var totalAmount = cartService.CalculateTotal();
            var vatAmount = new Amount(0);
            try
            {
                var cardRequest = new CardPaymentRequest(Operation.Purchase, PaymentIntent.Authorization, new Currency("SEK"),
                                                                                   new List<IPrice>
                                                                                   {
                                                                                       new Price(new Amount(totalAmount),
                                                                                                 PriceType.CreditCard, vatAmount)
                                                                                   },
                                                                                   "Test Purchase", payeeInfoOptions.PayeeReference,
                                                                                   new Language("sv-SE"),
                                                                                   new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                                            urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                                            urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                                   new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                                 payeeInfoOptions.PayeeReference));

                var cardPayment = await swedbankPayClient.Payments.CardPayments.Create(cardRequest);
                cartService.PaymentLink = cardPayment.Payment.Id.OriginalString;
                cartService.Instrument = PaymentInstrument.CreditCard;
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
        


        public async Task<ITrustlyPaymentResponse> CreateTrustlyPayment()
        {
            var totalAmount = cartService.CalculateTotal();
            var vatAmount = new Amount(0);
            try
            {
                var trustlyPaymentRequest = new TrustlyPaymentRequest(new Currency("SEK"),
                                                                                     new List<IPrice>
                                                                                     {
                                                                                         new Price(new Amount(totalAmount),
                                                                                                   PriceType.Trustly,
                                                                                                   vatAmount)
                                                                                     },
                                                                                     "Test Purchase", payeeInfoOptions.PayeeReference, "useragent", new Language("sv-SE"),
                                                                                     new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                                              urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                                              urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                                     new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                                   payeeInfoOptions.PayeeReference));
                var trustlyPayment = await swedbankPayClient.Payments.TrustlyPayments.Create(trustlyPaymentRequest);
                cartService.PaymentLink = trustlyPayment.Payment.Id.OriginalString;
                cartService.Instrument = PaymentInstrument.Trustly;
                cartService.PaymentOrderLink = null;
                cartService.Update();

                return trustlyPayment;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return null;
            }
        }

        public async Task<ISwishPaymentResponse> CreateSwishPayment()
        {
            var totalAmount = cartService.CalculateTotal();
            var vatAmount = new Amount(0);
            try
            {
                var swishRequest = new SwishPaymentRequest(new List<IPrice>
                                                                                     {
                                                                                         new Price(new Amount(totalAmount),
                                                                                                   PriceType.Swish, vatAmount)
                                                                                     },
                                                                                     "Test Purchase",
                                                                                     payeeInfoOptions.PayeeReference, "useragent", new Language("sv-SE"), new Urls(urls.HostUrls, urls.CompleteUrl,
                                                                                              urls.TermsOfServiceUrl, urls.CancelUrl,
                                                                                              urls.PaymentUrl, urls.CallbackUrl, urls.LogoUrl),
                                                                                     new PayeeInfo(payeeInfoOptions.PayeeId,
                                                                                                   payeeInfoOptions.PayeeReference),
                                                                                     new PrefillInfo(new Msisdn("+46739000001")));
                var swishPayment = await swedbankPayClient.Payments.SwishPayments.Create(swishRequest);
                cartService.PaymentLink = swishPayment.Payment.Id.OriginalString;
                cartService.Instrument = PaymentInstrument.Swish;
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

            var swedbankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = CultureInfo.GetCultureInfo("sv-SE"),
                UseAnonymousCheckout = false
            };
            return View("Checkout", swedbankPaySource);
        }


        public async Task<IActionResult> LoadPaymentMenu()
        {
            var response = await CreatePaymentOrder();

            var jsSource = response.Operations.View.Href;

            var swedbankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = CultureInfo.GetCultureInfo("sv-SE"),
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
            };

            return View("Checkout", swedbankPaySource);
        }

        public IActionResult LoadCardPaymentMenu()
        {
            return View("Payment");
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    var order = await context.Orders
        //        .FirstOrDefaultAsync();
        //    if (order == null)
        //        return NotFound();

        //    var paymentOrder = await swedbankPayClient.PaymentOrder.Get(new Uri(order.PaymentOrderLink, UriKind.RelativeOrAbsolute));

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

            var swedbankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = CultureInfo.GetCultureInfo("sv-SE"),
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
            };

            return View("Checkout", swedbankPaySource);
        }

        [HttpPost]
        public async Task<JsonResult> GetPaymentJsSource(PaymentInstrument instrument)
        {
            switch (instrument)
            {
                case PaymentInstrument.CreditCard:
                    var cardPayment = await CreateCardPayment().ConfigureAwait(false);
                    return new JsonResult(cardPayment.Operations.ViewAuthorization.Href);
                    
                case PaymentInstrument.Swish:
                    var swishPayment = await CreateSwishPayment().ConfigureAwait(false);
                    return new JsonResult(swishPayment.Operations.ViewSales.Href);

                case PaymentInstrument.Trustly:
                    var trustlyPayment = await CreateTrustlyPayment().ConfigureAwait(false);
                    return new JsonResult(trustlyPayment.Operations.ViewSale.Href);
                default :
                    return null;
            }
        }
 


        public ViewResult Aborted()
        {
            return View();
        }


        public ViewResult Thankyou()
        {
            if (cartService.CartLines != null && cartService.CartLines.Any())
            {
                var products = cartService.CartLines.Select(p => p.Product);
                context.Products.AttachRange(products);

                context.Orders.Add(new Order
                {
                    PaymentOrderLink = cartService.PaymentOrderLink != null ? new Uri(cartService.PaymentOrderLink, UriKind.RelativeOrAbsolute) : null,
                    PaymentLink = cartService.PaymentLink != null ? new Uri(cartService.PaymentLink, UriKind.RelativeOrAbsolute) : null,
                    Instrument = cartService.Instrument,
                    Lines = cartService.CartLines.ToList()
                });
                context.SaveChanges(true);
                cartService.Clear();
            }
            return View();
        }
    }
}