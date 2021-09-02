using System;
using System.Collections;
using System.Collections.Generic;
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
        protected string _referenceLink;
        protected Uri link;

        public PaymentTests(string driverAlias)
            : base(driverAlias)
        {
        }

        protected SwedbankPayClient SwedbankPayClient { get; private set; }


        [OneTimeSetUp]
        public void Setup()
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.local.json", true)
                .AddEnvironmentVariables()
                .Build();

            var baseAddress = configRoot.GetSection("SwedbankPay:ApiBaseUrl").Value;
            var authHeader = configRoot.GetSection("SwedbankPay:Token").Value;
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authHeader);

            SwedbankPayClient = new SwedbankPayClient(httpClient);
        }

        protected OrdersPage GoToOrdersPage(Product[] products, PayexInfo payexInfo, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            ThankYouPage page = null;

            switch (payexInfo)
            {
                case PayexCardInfo cardInfo:
                    page = PayWithPayexCard(products, cardInfo, checkout);
                    break;
                case PayexSwishInfo swishInfo:
                    page = PayWithPayexSwish(products, swishInfo, checkout);
                    break;
                case PayexInvoiceInfo invoiceInfo:
                    page = PayWithPayexInvoice(products, invoiceInfo, checkout);
                    break;
                case PayexTrustlyInfo trustlyInfo:
                    page = PayWithPayexTrustly(products, trustlyInfo, checkout);
                    break;
            }

            return page?
                .ThankYou.IsVisible.WaitTo.Within(120).BeTrue()
                .Header.Orders.ClickAndGo()
                .Do(x =>
                {
                    if (checkout == Checkout.Option.LocalPaymentMenu)
                    {
                        x.PaymentLink.StoreValueAsUri(out link)
                        .PaymentLink.Should.Contain(_referenceLink);
                    }
                    else
                    {
                        x.PaymentOrderLink.StoreValueAsUri(out link)
                        .PaymentOrderLink.Should.Contain(_referenceLink);
                    }
                });
        }

        protected PayexCardFramePage GoToPayexCardPaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            PayexCardFramePage frame = null;

            switch (checkout)
            {
                case Checkout.Option.LocalPaymentMenu:
                    frame = GoToLocalPaymentPage(products, checkout)
                        .CreditCard.IsVisible.WaitTo.BeTrue()
                        .CreditCard.Click()
                        .PaymentFrame.IsVisible.WaitTo.BeTrue()
                        .PaymentFrame.SwitchTo<PayexCardFramePage>()
                        .PageSource.WaitTo.Within(15).Contain("/psp/");

                    _referenceLink = frame.PageSource.GetPaymentOrderFromBody();

                    break;

                default:

                    frame = GoToPaymentFramePage(products, checkout)
                        .PaymentMethods[x => x.Name == PaymentMethods.Card].IsVisible.WaitTo.BeTrue()
                        .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                        .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexCardFramePage>();

                    if (frame.CardTypeSelector.Exists())
                    {
                        frame.CardTypeSelector.Check();
                    }

                    break;
            }

            return frame;
        }

        protected PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            PayexInvoiceFramePage frame = null;

            switch (checkout)
            {
                case Checkout.Option.LocalPaymentMenu:
                    frame = GoToLocalPaymentPage(products, checkout)
                        .Invoice.IsVisible.WaitTo.BeTrue()
                        .Invoice.Click()
                        .PaymentFrame.IsVisible.WaitTo.BeTrue()
                        .PaymentFrame.SwitchTo<PayexInvoiceFramePage>()
                        .PageSource.WaitTo.Within(15).Contain("/psp/");

                    _referenceLink = frame.PageSource.GetPaymentOrderFromBody();

                    break;
                default:
                    frame = GoToPaymentFramePage(products, checkout)
                        .PaymentMethods[x => x.Name == PaymentMethods.Invoice].IsVisible.WaitTo.BeTrue()
                        .PaymentMethods[x => x.Name == PaymentMethods.Invoice].Click()
                        .PaymentMethods[x => x.Name == PaymentMethods.Invoice].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
                    break;
            }

            return frame;
        }

        protected PayexSwishFramePage GoToPayexSwishPaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            PayexSwishFramePage frame = null;

            switch (checkout)
            {
                case Checkout.Option.LocalPaymentMenu:
                    frame = GoToLocalPaymentPage(products, checkout)
                                .Swish.IsVisible.WaitTo.BeTrue()
                                .Swish.Click()
                                .PaymentFrame.IsVisible.WaitTo.BeTrue()
                                .PaymentFrame.SwitchTo<PayexSwishFramePage>()
                                .PageSource.WaitTo.Within(15).Contain("/psp/");

                    _referenceLink = frame.PageSource.GetPaymentOrderFromBody();

                    break;
                default:
                    frame = GoToPaymentFramePage(products, checkout)
                        .PaymentMethods[x => x.Name == PaymentMethods.Swish].IsVisible.WaitTo.BeTrue()
                        .PaymentMethods[x => x.Name == PaymentMethods.Swish].Click()
                        .PaymentMethods[x => x.Name == PaymentMethods.Swish].PaymentFrame.SwitchTo<PayexSwishFramePage>();
                    break;
            }

            return frame;
        }

        protected PayexTrustlyFramePage GoToPayexTrustlyPaymentFrame(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            PayexTrustlyFramePage frame = null;

            switch (checkout)
            {
                case Checkout.Option.LocalPaymentMenu:
                    frame = GoToLocalPaymentPage(products, checkout)
                        .Trustly.IsVisible.WaitTo.BeTrue()
                        .Trustly.Click()
                        .PaymentFrame.IsVisible.WaitTo.BeTrue()
                        .PaymentFrame.SwitchTo<PayexTrustlyFramePage>()
                        .PageSource.WaitTo.Within(15).Contain("/psp/");

                    _referenceLink = frame.PageSource.GetPaymentOrderFromBody();

                    break;
                default:
                    frame = GoToPaymentFramePage(products, checkout)
                        .PaymentMethods[x => x.Name == PaymentMethods.Trustly].IsVisible.WaitTo.BeTrue()
                        .PaymentMethods[x => x.Name == PaymentMethods.Trustly].Click()
                        .PaymentMethods[x => x.Name == PaymentMethods.Trustly].PaymentFrame.SwitchTo<PayexTrustlyFramePage>();
                    break;
            }

            return frame;
        }

        protected PaymentFramePage GoToPaymentFramePage(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            PaymentFramePage frame = null;

            switch (checkout)
            {
                case Checkout.Option.Standard:
                    frame = GoToPayexPaymentPage(products, checkout)
                        .IdentificationFrame.SwitchTo()
                        .Email.IsVisible.WaitTo.BeTrue()
                        .Email.SetWithSpeed(TestDataService.Email, interval: 0.1)
                        .PhoneNumber.SetWithSpeed(TestDataService.SwedishPhoneNumber, interval: 0.1)
                        .Next.Click().SwitchToRoot<PaymentPage>().Wait(TimeSpan.FromSeconds(20))
                        .PaymentMethodsFrame.SwitchTo();
                    break;
                default:
                    frame = GoToPayexPaymentPage(products, checkout)
                        .PaymentMethodsFrame.IsVisible.WaitTo.BeTrue()
                        .PaymentMethodsFrame.SwitchTo();
                    break;
            }

            _referenceLink = frame.PageSource.GetPaymentOrderFromBody();

            return frame;
        }

        protected LocalPaymentMenuPage GoToLocalPaymentPage(Product[] products, Checkout.Option checkout)
        {
            return SelectProducts(products)
                    .LocalPaymentMenu.ClickAndGo();
                    
        }

        protected PaymentPage GoToPayexPaymentPage(Product[] products, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            return checkout switch
            {
                Checkout.Option.Standard => SelectProducts(products).StandardCheckout.ClickAndGo(),
                _ => SelectProducts(products).AnonymousCheckout.ClickAndGo()
            };
        }

        protected ProductsPage SelectProducts(Product[] products)
        {
            return Go.To<ProductsPage>()
                .Do((x) =>
                {
                    if (x.Header.ClearOrders.Exists(new SearchOptions { Timeout = new TimeSpan(0, 0, 0, 0, 500), IsSafely = true }))
                    {
                        x
                        .Header.ClearOrders.Click()
                        .Header.Products.Click();
                    }

                    foreach (var product in products)
                    {
                        x
                        .Products.Rows[y => y.Name == product.Name].AddToCart.Click()
                        .Products.Rows[y => y.Name == product.Name].Price.StorePrice(out var price);

                        product.UnitPrice = price;

                        if (product.Quantity != 1)
                        {
                            x
                            .CartProducts.Rows[y => y.Name == product.Name].Quantity.Set(product.Quantity)
                            .CartProducts.Rows[y => y.Name == product.Name].Update.Click();
                        }
                    }
                });
        }

        protected ThankYouPage PayWithPayexCard(Product[] products, PayexCardInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            return checkout switch
            {
                Checkout.Option.Standard => GoToPayexCardPaymentFrame(products, checkout)
                                       .Do(x =>
                                       {
                                           if (x.PreFilledCards.Exists(new SearchOptions { IsSafely = true, Timeout = TimeSpan.FromSeconds(3) }))
                                           {
                                               if (x.PreFilledCards.Items[y => y.CreditCardNumber.Value.Contains(info.CreditCardNumber.Substring(info.CreditCardNumber.Length - 4))].Exists())
                                               {
                                                   x
                                                   .PreFilledCards
                                                   .Items[
                                                       y => y.CreditCardNumber.Value.Contains(
                                                           info.CreditCardNumber.Substring(info.CreditCardNumber.Length - 4))].Click()
                                                   .Cvc.SetWithSpeed(info.Cvc, interval: 0.1);
                                               }
                                               else
                                               {
                                                   x
                                                   .AddNewCard.Click()
                                                   .CreditCardNumber.SetWithSpeed(TestDataService.CreditCardNumber, interval: 0.1)
                                                   .ExpiryDate.SetWithSpeed(TestDataService.CreditCardExpirationDate, interval: 0.1)
                                                   .Cvc.SetWithSpeed(TestDataService.CreditCardCvc, interval: 0.1);
                                               }
                                           }
                                           else if (x.CreditCardNumber.Exists(new SearchOptions { IsSafely = true, Timeout = TimeSpan.FromSeconds(3) }))
                                           {
                                               x
                                               .CreditCardNumber.SetWithSpeed(info.CreditCardNumber, interval: 0.1)
                                               .ExpiryDate.SetWithSpeed(info.ExpiryDate, interval: 0.1)
                                               .Cvc.SetWithSpeed(info.Cvc, interval: 0.1);
                                           }
                                       })
                                       .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                                       .Pay.ClickAndGo(),
                _ => GoToPayexCardPaymentFrame(products, checkout)
                    .CreditCardNumber.IsVisible.WaitTo.BeTrue()
                    .CreditCardNumber.SetWithSpeed(info.CreditCardNumber, interval: 0.1)
                    .ExpiryDate.SetWithSpeed(info.ExpiryDate, interval: 0.1)
                    .Cvc.SetWithSpeed(info.Cvc, interval: 0.1)
                    .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                    .Pay.ClickAndGo(),
            };
        }

        protected ThankYouPage PayWithPayexInvoice(Product[] products, PayexInvoiceInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            return checkout switch
            {
                Checkout.Option.Standard => GoToPayexInvoicePaymentFrame(products, checkout)
                                       .PersonalNumber.IsVisible.WaitTo.BeTrue()
                                       .PersonalNumber.SetWithSpeed(info.PersonalNumber.Substring(info.PersonalNumber.Length - 4), interval: 0.15)
                                       .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                                       .Pay.ClickAndGo(),
                _ => GoToPayexInvoicePaymentFrame(products, checkout)
                    .PersonalNumber.IsVisible.WaitTo.BeTrue()
                    .PersonalNumber.SetWithSpeed(info.PersonalNumber, interval: 0.1)
                    .Email.SetWithSpeed(info.Email, interval: 0.1)
                    .PhoneNumber.SetWithSpeed(info.PhoneNumber, interval: 0.1)
                    .ZipCode.SetWithSpeed(info.ZipCode, interval: 0.1)
                    .Next.Click()
                    .Wait(TimeSpan.FromSeconds(5))
                    .Pay.IsVisible.WaitTo.Within(20).BeTrue()
                    .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                    .Pay.ClickAndGo(),
            };
        }

        protected ThankYouPage PayWithPayexSwish(Product[] products, PayexSwishInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {
            return checkout switch
            {
                Checkout.Option.Standard => GoToPayexSwishPaymentFrame(products, checkout)
                                   .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                                   .Pay.ClickAndGo(),
                _ => GoToPayexSwishPaymentFrame(products, checkout)
                      .SwishNumber.IsVisible.WaitTo.BeTrue()
                      .SwishNumber.SetWithSpeed(info.SwishNumber, interval: 0.1)
                      .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Sum(x => x.UnitPrice / 100 * x.Quantity)))} kr")
                      .Pay.ClickAndGo(),
            };
        }

        protected ThankYouPage PayWithPayexTrustly(Product[] products, PayexTrustlyInfo info, Checkout.Option checkout = Checkout.Option.Anonymous)
        {

            return GoToPayexTrustlyPaymentFrame(products, checkout)
                .Submit.IsVisible.WaitTo.Within(15).BeTrue()
                .Submit.ClickAndGo<TrustlyPaymentPage>()
                .Banks[0].IsVisible.WaitTo.Within(15).BeTrue()
                .Banks[0].Click()
                .Next.Click()
                .PersonalNumber.Set(TestDataService.PersonalNumber)
                .SecurityCodeOption.Click()
                .Next.Click()
                .MessageCode.StoreValue(out string code)
                .Code.Set(code)
                .Next.Click()
                .AccountOptions.IsVisible.WaitTo.Within(60).BeTrue()
                .Next.Click()
                .MessageCode.StoreValue(out code)
                .Code.Set(code)
                .Next.Click()
                .PageUrl.Should.Within(TimeSpan.FromSeconds(60)).Contain("Thankyou")
                .SwitchToRoot<ThankYouPage>()
                .ThankYou.IsVisible.WaitTo.BeTrue();
        }

        protected static IEnumerable TestData(bool singleProduct = true, string paymentMethod = PaymentMethods.Card)
        {
            var data = new List<object>();

            if (singleProduct)
            {
                data.Add(new[]
                {
                    new Product { Name = Products.Product1, Quantity = 1 }
                });
            }
            else
            {
                data.Add(new[]
                {
                    new Product { Name = Products.Product1, Quantity = 3 },
                    new Product { Name = Products.Product2, Quantity = 2 }
                });
            }

            switch (paymentMethod)
            {
                case PaymentMethods.Card:
                    data.Add(new PayexCardInfo(TestDataService.CreditCardNumber, TestDataService.CreditCardExpirationDate,
                                               TestDataService.CreditCardCvc));
                    break;

                case PaymentMethods.Swish:
                    data.Add(new PayexSwishInfo(TestDataService.SwishPhoneNumber));
                    break;

                case PaymentMethods.Invoice:
                    data.Add(new PayexInvoiceInfo(TestDataService.PersonalNumberShort, TestDataService.Email, TestDataService.PhoneNumber,
                                                  TestDataService.ZipCode));
                    break;

                case PaymentMethods.Trustly:
                    data.Add(new PayexTrustlyInfo());
                    break;
            }

            yield return data.ToArray();
        }
    }
}
