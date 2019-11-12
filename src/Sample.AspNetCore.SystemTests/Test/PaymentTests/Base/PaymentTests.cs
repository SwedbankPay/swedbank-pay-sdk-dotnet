using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels;
using System.Collections.Generic;
using System.Collections;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using Sample.AspNetCore.SystemTests.PageObjectModels.Payment;
using System;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;
using Sample.AspNetCore.SystemTests.PageObjectModels.Orders;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Sample.AspNetCore.SystemTests.Test.Api;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public abstract class PaymentTests : TestBase
    {
        protected HttpClientService _httpClientService;

        public PaymentTests(string driverAlias) : base(driverAlias) { }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _httpClientService = new HttpClientService();
        }

        protected static IEnumerable TestData(bool singleProduct = true, string paymentMethod = PaymentMethods.Card)
        {
            List<object> data = new List<object>();

            if (singleProduct)
            {
                data.Add(new Product[]
                {
                    new Product { Name = Products.Product1, Quantity= 1 }
                });
            }
            else
            {
                data.Add(new Product[]
                {
                    new Product { Name = Products.Product1, Quantity= 3 },
                    new Product { Name = Products.Product2, Quantity= 2 }
                });
            }

            switch (paymentMethod)
            {
                case PaymentMethods.Card:
                    data.Add(new PayexCardInfo(TestDataService.CreditCardNumber, TestDataService.CreditCardExpiratioDate, TestDataService.CreditCardCVC));
                    break;

                case PaymentMethods.Swish:
                    data.Add(new PayexSwishInfo(TestDataService.SwishPhoneNumber));
                    break;

                case PaymentMethods.Invoice:
                    data.Add(new PayexInvoiceInfo(TestDataService.PersonalNumberShort, TestDataService.Email, TestDataService.PhoneNumber, TestDataService.ZipCode));
                    break;
            }

            yield return data.ToArray();
        }

        #region Method Helpers

        protected PaymentPage GoToPaymentPage(Product[] products, bool standardCheckout = false)
        {
            var page = Go.To<ProductsPage>();

            if (page.Header.ClearOrders.Exists(new SearchOptions { Timeout = new TimeSpan(0, 0, 0, 0, 500), IsSafely = true }))
            {
                page
                .Header.ClearOrders.Click()
                .Header.Products.Click();
            }

            foreach (var product in products)
            {
                page
                .Products.Rows[x => x.Name == product.Name].AddToCart.Click()
                .Products.Rows[x => x.Name == product.Name].Price.StorePrice(out int price);

                product.UnitPrice = price;

                if (product.Quantity != 1)
                {
                    page
                    .CartProducts.Rows[x => x.Name == product.Name].Quantity.Set(product.Quantity)
                    .CartProducts.Rows[x => x.Name == product.Name].Update.Click();
                }
            }

            return standardCheckout 
                ? page.StandardCheckout.ClickAndGo()
                : page.Checkout.ClickAndGo();
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

        protected PayexCardFramePage GoToPayexCardPaymentFrame(Product[] products, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(products, standardCheckout)
                    .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                    .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexCardFramePage>();
        }

        protected PayexSwishFramePage GoToPayexSwishPaymentFrame(Product[] products, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(products, standardCheckout)
                    .PaymentMethods[x => x.Name == PaymentMethods.Swish].Click()
                    .PaymentMethods[x => x.Name == PaymentMethods.Swish].PaymentFrame.SwitchTo<PayexSwishFramePage>();
        }

        protected PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(Product[] products, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(products, standardCheckout)
                    .PaymentMethods[x => x.Name == PaymentMethods.Invoice].Click()
                    .PaymentMethods[x => x.Name == PaymentMethods.Invoice].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
        }

        protected ThankYouPage PayWithPayexCard(Product[] products, PayexCardInfo info, bool standardCheckout = false)
        {
            return standardCheckout
                ? GoToPayexCardPaymentFrame(products, standardCheckout)
                    .Cvc.Set(info.Cvc)
                    .Pay.ClickAndGo()
                : GoToPayexCardPaymentFrame(products, standardCheckout)
                    .CreditCardNumber.Set(info.CreditCardNumber)
                    .ExpiryDate.Set(info.ExpiryDate)
                    .Cvc.Set(info.Cvc)
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

        #endregion

    }
}
