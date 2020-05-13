using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Atata;
using Microsoft.Extensions.Configuration;
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
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

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

            var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config["payexTestToken"]);
            #elif RELEASE
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("Payex.Api.Url", EnvironmentVariableTarget.User))
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("Payex.Api.Token", EnvironmentVariableTarget.User));
            #endif

            SwedbankPayClient = new SwedbankPayClient(httpClient);
        }


        protected OrdersPage GoToOrdersPage(Product[] products, PayexInfo payexInfo, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (payexInfo)
            {
                case PayexCardInfo cardInfo:

                    return PayWithPayexCard(products, cardInfo, checkout).Header.Orders.ClickAndGo();

                case PayexSwishInfo swishInfo:

                    return PayWithPayexSwish(products, swishInfo, checkout).Header.Orders.ClickAndGo();

                case PayexInvoiceInfo invoiceInfo:

                    return PayWithPayexInvoice(products, invoiceInfo, checkout).Header.Orders.ClickAndGo();
            }

            return null;
        }


        protected PayexCardFramePage GoToPayexCardPaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.LocalPaymentMenu:
                    return GoToLocalPaymentPage(products, checkout)
                        .CreditCard.Click()
                        .PaymentFrame.SwitchTo<PayexCardFramePage>();

                case Checkout.Option.Anonymous:
                case Checkout.Option.Standard:
                default:

                    return GoToPaymentFramePage(products, checkout)
                        .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                        .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexCardFramePage>();


            }
            
        }


        protected PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            return GoToPaymentFramePage(products, checkout)
                .PaymentMethods[x => x.Name == PaymentMethods.Invoice].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Invoice].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
        }


        protected PayexSwishFramePage GoToPayexSwishPaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.LocalPaymentMenu:
                    return GoToLocalPaymentPage(products, checkout)
                        .Swish.Click()
                        .PaymentFrame.SwitchTo<PayexSwishFramePage>();

                case Checkout.Option.Anonymous:
                case Checkout.Option.Standard:
                default:

                    return GoToPaymentFramePage(products, checkout)
                        .PaymentMethods[x => x.Name == PaymentMethods.Swish].Click()
                        .PaymentMethods[x => x.Name == PaymentMethods.Swish].PaymentFrame.SwitchTo<PayexSwishFramePage>();


            }
            
        }


        protected PaymentFramePage GoToPaymentFramePage(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.Standard:

                    return GoToPayexPaymentPage(products, checkout)
                    .IdentificationFrame.SwitchTo()
                    .Email.Set(TestDataService.Email)
                    .PhoneNumber.Set(TestDataService.SwedishPhoneNumber)
                    .Next.Click().SwitchToRoot<PaymentPage>()
                    .PaymentMethodsFrame.SwitchTo();

                case Checkout.Option.Anonymous:
                default:

                    return GoToPayexPaymentPage(products, checkout)
                    .PaymentMethodsFrame.SwitchTo();

            }
        }


        protected LocalPaymentMenuPage GoToLocalPaymentPage(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            return SelectProducts(products)
                    .LocalPaymentMenu.ClickAndGo();
        }


        protected PaymentPage GoToPayexPaymentPage(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.Standard:
                    return SelectProducts(products).StandardCheckout.ClickAndGo();

                case Checkout.Option.Anonymous:
                default:
                    return SelectProducts(products).AnonymousCheckout.ClickAndGo();
            }
        }


        protected ProductsPage SelectProducts(Product[] products)
        {
            return Go.To<ProductsPage>()
                .Do((x) => 
                {
                    if (x.Header.ClearOrders.Exists(new SearchOptions { Timeout = new TimeSpan(0, 0, 0, 0, 500), IsSafely = true }))
                        x
                        .Header.ClearOrders.Click()
                        .Header.Products.Click();

                    foreach (var product in products)
                    {
                        x
                        .Products.Rows[y => y.Name == product.Name].AddToCart.Click()
                        .Products.Rows[y => y.Name == product.Name].Price.StorePrice(out var price);

                        product.UnitPrice = price;

                        if (product.Quantity != 1)
                            x
                            .CartProducts.Rows[y => y.Name == product.Name].Quantity.Set(product.Quantity)
                            .CartProducts.Rows[y => y.Name == product.Name].Update.Click();
                    }
                });
        }

        protected ThankYouPage PayWithPayexCard(Product[] products, PayexCardInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.Standard:
                    return GoToPayexCardPaymentFrame(products, checkout)
                        .Do(x =>
                        {
                            if(x.PreFilledCards.Items[y => y.CreditCardNumber.Value.Contains(info.CreditCardNumber.Substring(info.CreditCardNumber.Length - 4))].Exists())
                            {
                                x.PreFilledCards
                                    .Items[
                                        y => y.CreditCardNumber.Value.Contains(
                                            info.CreditCardNumber.Substring(info.CreditCardNumber.Length - 4))].Click()
                                    .Cvc.Set(info.Cvc);
                            }
                            else
                            {
                                x.AddNewCard.Click()
                                    .CreditCardNumber.Set(TestDataService.CreditCardNumber)
                                    .ExpiryDate.Set(TestDataService.CreditCardExpiratioDate)
                                    .Cvc.Set(TestDataService.CreditCardCvc);
                            }

                                

                        })
                    .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                    .Pay.ClickAndGo();

                case Checkout.Option.LocalPaymentMenu:
                case Checkout.Option.Anonymous:
                default:

                    return GoToPayexCardPaymentFrame(products, checkout)
                    .CreditCardNumber.Set(info.CreditCardNumber)
                    .ExpiryDate.Set(info.ExpiryDate)
                    .Cvc.Set(info.Cvc)
                    .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                    .Pay.ClickAndGo();
            }
        }


        protected ThankYouPage PayWithPayexInvoice(Product[] products, PayexInvoiceInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.Standard:
                    return GoToPayexInvoicePaymentFrame(products, checkout)
                        .PersonalNumber.Set(info.PersonalNumber.Substring(info.PersonalNumber.Length - 4))
                        .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                        .Pay.ClickAndGo();

                case Checkout.Option.Anonymous:
                default:

                    return GoToPayexInvoicePaymentFrame(products, checkout)
                        .PersonalNumber.Set(info.PersonalNumber)
                        .Email.Set(info.Email)
                        .PhoneNumber.Set(info.PhoneNumber)
                        .ZipCode.Set(info.ZipCode)
                        .Next.Click()
                        .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                        .Pay.ClickAndGo();
            }
        }


        protected ThankYouPage PayWithPayexSwish(Product[] products, PayexSwishInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            switch (checkout)
            {
                case Checkout.Option.Standard:

                    return GoToPayexSwishPaymentFrame(products, checkout)
                    .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                    .Pay.ClickAndGo();

                case Checkout.Option.LocalPaymentMenu:
                case Checkout.Option.Anonymous:
                default:

                    return GoToPayexSwishPaymentFrame(products, checkout)
                    .SwishNumber.Set(info.SwishNumber)
                    .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                    .Pay.ClickAndGo();
            }
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
