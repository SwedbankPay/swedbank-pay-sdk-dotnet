using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.AspNetCore3.Constants;
using Sample.AspNetCore3.Extensions;
using Sample.AspNetCore3.Models;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore3.Controllers
{
    public class PaymentController : Controller
    {
        private readonly SwedbankPayOptions _optionsAccessor;

        public const string CartSessionKey = "_Cart";

        public PaymentController(IOptionsMonitor<SwedbankPayOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.CurrentValue;
        }


        // GET: Payment
        public async Task<ActionResult> Index(Cart cart)
        {

            var test = _optionsAccessor.ApiBaseUrl;
            SaveCart(cart);

            var swedbankPayOptions = new SwedbankPayOptions
            {
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com"),
                Token = "588431aa485611f8fce876731a1734182ca0c44fcad6b8d989e22f444104aadf",
                CallBackUrl = new Uri("https://payex.eu.ngrok.io/payment-callback?orderGroupId={orderGroupId}"),
                CompletePageUrl = new Uri("https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}"),
                CancelPageUrl = new Uri("https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}"),
                MerchantId = "91a4c8e0-72ac-425c-a687-856706f9e9a1"
            };

            var swedbankPayClient = new SwedbankPayClient(swedbankPayOptions);

            //var amount = cart.CartLinePrice*cart.CartLineQuantity;
            //var paymentOrderRequest = CreatePaymentOrderRequestContainer(amount, 0);

            //paymentOrderRequest.Paymentorder.OrderItems = new List<OrderItem>();

            //paymentOrderRequest.Paymentorder.OrderItems.Add(new OrderItem
            //{
            //    Reference = "p1",
            //    Name = "Product1",
            //    Type = "PRODUCT",
            //    Class = "ProductGroup1",
            //    ItemUrl = "https://example.com/products/123",
            //    ImageUrl = "https://example.com/products/123.jpg",
            //    Description = "Product 1 description",
            //    DiscountDescription = "Volume discount",
            //    Quantity = cart.CartLineQuantity,
            //    QuantityUnit = "pcs",
            //    UnitPrice = cart.CartLinePrice,
            //    VatPercent = 0,
            //    Amount = (int?) amount,
            //    VatAmount = 0
            //});

            //var response = await swedbankPayClient.PaymentOrders.CreatePaymentOrder(paymentOrderRequest);
            //var jsSource = response.Operations.FirstOrDefault(x => x.Rel == Operations.ViewPaymentOrder)?.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource();

            //swedBankPaySource.JavascriptSource = jsSource;
            //swedBankPaySource.Culture = "sv-SE";
            //swedBankPaySource.UseAnonymousCheckout = true;
            
            return View(swedBankPaySource);
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payment/Create
        public ActionResult Create(Cart cart)
        {
            

            //var swedbankPayClient.PaymentOrders.CreatePaymentOrder();
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private PaymentOrderRequestContainer CreatePaymentOrderRequestContainer(long amount = 30000, long vatAmount = 7500)
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
                    PayeeInfo = new PayeeInfo
                    {
                        PayeeId = "91a4c8e0-72ac-425c-a687-856706f9e9a1",
                        PayeeReference = DateTime.Now.Ticks.ToString(),
                    }
                }
            };
            return paymentOrderRequestContainer;
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson(CartSessionKey, cart);
        }


    }
}