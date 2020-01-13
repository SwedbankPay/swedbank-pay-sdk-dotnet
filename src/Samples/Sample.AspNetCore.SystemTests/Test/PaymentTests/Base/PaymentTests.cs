using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

using Atata;

using NUnit.Framework;

using Sample.AspNetCore.SystemTests.PageObjectModels;
using Sample.AspNetCore.SystemTests.PageObjectModels.Orders;
using Sample.AspNetCore.SystemTests.PageObjectModels.Payment;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Base;
using Sample.AspNetCore.SystemTests.Test.Helpers;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Base
{
    public abstract class PaymentTests : TestBase
    {
        public PaymentTests(string driverAlias)
            : base(driverAlias)
        {
        }


        protected HttpClientService HttpClientService { get; private set; }
        protected SwedbankPayClient SwedbankPayClient { get; private set; }


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            #if DEBUG
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.externalintegration.payex.com")
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["payexTestToken"]);
            #elif RELEASE
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("Payex.Api.Url", EnvironmentVariableTarget.User))
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("Payex.Api.Token", EnvironmentVariableTarget.User));
            #endif

            SwedbankPayClient = new SwedbankPayClient(httpClient);
        }


        protected OrdersPage GoToOrdersPage(Product[] products, PayexInfo payexInfo, bool standardCheckout = false)
        {
            switch (payexInfo)
            {
                case PayexCardInfo cardInfo:

                    return PayWithPayexCard(products, cardInfo, standardCheckout).Header.Orders.ClickAndGo();

                case PayexSwishInfo swishInfo:

                    return PayWithPayexSwish(products, swishInfo, standardCheckout).Header.Orders.ClickAndGo();

                case PayexInvoiceInfo invoiceInfo:

                    return PayWithPayexInvoice(products, invoiceInfo, standardCheckout).Header.Orders.ClickAndGo();
            }

            return null;
        }


        protected PayexCardFramePage GoToPayexCardPaymentFrame(Product[] products, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(products, standardCheckout)
                .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexCardFramePage>();
        }


        protected PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(Product[] products, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(products, standardCheckout)
                .PaymentMethods[x => x.Name == PaymentMethods.Invoice].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Invoice].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
        }


        protected PayexSwishFramePage GoToPayexSwishPaymentFrame(Product[] products, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(products, standardCheckout)
                .PaymentMethods[x => x.Name == PaymentMethods.Swish].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Swish].PaymentFrame.SwitchTo<PayexSwishFramePage>();
        }


        protected PaymentFramePage GoToPaymentFramePage(Product[] products, bool standardCheckout = false)
        {
            return standardCheckout
                ? GoToPaymentPage(products, standardCheckout)
                    .IdentificationFrame.SwitchTo()
                    .Email.Set(TestDataService.Email)
                    .PhoneNumber.Set(TestDataService.SwedishPhoneNumber)
                    .Next.Click().SwitchToRoot<PaymentPage>()
                    .PaymentMethodsFrame.SwitchTo()
                : GoToPaymentPage(products, standardCheckout)
                    .PaymentMethodsFrame.SwitchTo();
        }


        protected PaymentPage GoToPaymentPage(Product[] products, bool standardCheckout = false)
        {
            var page = Go.To<ProductsPage>();

            if (page.Header.ClearOrders.Exists(new SearchOptions { Timeout = new TimeSpan(0, 0, 0, 0, 500), IsSafely = true }))
                page
                    .Header.ClearOrders.Click()
                    .Header.Products.Click();

            foreach (var product in products)
            {
                page
                    .Products.Rows[x => x.Name == product.Name].AddToCart.Click()
                    .Products.Rows[x => x.Name == product.Name].Price.StorePrice(out var price);

                product.UnitPrice = price;

                if (product.Quantity != 1)
                    page
                        .CartProducts.Rows[x => x.Name == product.Name].Quantity.Set(product.Quantity)
                        .CartProducts.Rows[x => x.Name == product.Name].Update.Click();
            }

            return standardCheckout
                ? page.StandardCheckout.ClickAndGo()
                : page.Checkout.ClickAndGo();
        }


        protected ThankYouPage PayWithPayexCard(Product[] products, PayexCardInfo info, bool standardCheckout = false)
        {
            return standardCheckout
                ? GoToPayexCardPaymentFrame(products, standardCheckout)
                    .PreFilledCards.Items[x => x.CreditCardNumber.Value.Contains(info.CreditCardNumber.Substring(info.CreditCardNumber.Length - 4))].Click()
                    .Cvc.Set(info.Cvc)
                    .Pay.ClickAndGo()
                : GoToPayexCardPaymentFrame(products, standardCheckout)
                    .CreditCardNumber.Set(info.CreditCardNumber)
                    .ExpiryDate.Set(info.ExpiryDate)
                    .Cvc.Set(info.Cvc)
                    .Pay.ClickAndGo();
        }

        protected ThankYouPage PayWithPayexInvoice(Product[] products, PayexInvoiceInfo info, bool standardCheckout = false)
        {
            return GoToPayexInvoicePaymentFrame(products, standardCheckout)
                .PersonalNumber.Set(info.PersonalNumber)
                .Email.Set(info.Email)
                .PhoneNumber.Set(info.PhoneNumber)
                .ZipCode.Set(info.ZipCode)
                .Next.Click()
                .Pay.ClickAndGo();
        }


        protected ThankYouPage PayWithPayexSwish(Product[] products, PayexSwishInfo info, bool standardCheckout = false)
        {
            return standardCheckout
                ? GoToPayexSwishPaymentFrame(products, standardCheckout)
                    .Pay.ClickAndGo()
                : GoToPayexSwishPaymentFrame(products, standardCheckout)
                    .SwishNumber.Set(info.SwishNumber)
                    .Pay.ClickAndGo();
        }


        protected static IEnumerable TestData(bool singleProduct = true, string paymentMethod = PaymentMethods.Card)
        {
            var data = new List<object>();

            if (singleProduct)
                data.Add(new[]
                {
                    new Product { Name = Products.Product1, Quantity = 1 }
                });
            else
                data.Add(new[]
                {
                    new Product { Name = Products.Product1, Quantity = 3 },
                    new Product { Name = Products.Product2, Quantity = 2 }
                });

            switch (paymentMethod)
            {
                case PaymentMethods.Card:
                    data.Add(new PayexCardInfo(TestDataService.CreditCardNumber, TestDataService.CreditCardExpiratioDate,
                                               TestDataService.CreditCardCvc));
                    break;

                case PaymentMethods.Swish:
                    data.Add(new PayexSwishInfo(TestDataService.SwishPhoneNumber));
                    break;

                case PaymentMethods.Invoice:
                    data.Add(new PayexInvoiceInfo(TestDataService.PersonalNumberShort, TestDataService.Email, TestDataService.PhoneNumber,
                                                  TestDataService.ZipCode));
                    break;
            }

            yield return data.ToArray();
        }
    }
}