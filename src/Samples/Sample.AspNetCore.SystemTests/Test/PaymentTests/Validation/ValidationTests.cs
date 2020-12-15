using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Validation
{
    public class ValidationTests : Base.PaymentTests
    {
        public ValidationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationCard(Product[] products)
        {
            GoToPayexCardPaymentFrame(products)
                .CreditCardNumber.Set("abc")
                .ExpiryDate.Set("abcd")
                .Cvc.Set("abc")
                .CreditCardNumber.Click()
                .ValidationIcons[x => x.CreditCardNumber].Should.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.BeVisible()
                .CreditCardNumber.Clear()
                .CreditCardNumber.SetWithSpeed(TestDataService.CreditCardNumber, 0.1)
                .ExpiryDate.Clear()
                .ExpiryDate.SetWithSpeed(TestDataService.CreditCardExpirationDate, 0.1)
                .Cvc.Clear()
                .Cvc.SetWithSpeed(TestDataService.CreditCardCvc, 0.1)
                .ValidationIcons[x => x.CreditCardNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.Not.BeVisible();
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationInvoice(Product[] products)
        {
            GoToPayexInvoicePaymentFrame(products)
                .PersonalNumber.Set("abc")
                .Email.Set("abc")
                .PhoneNumber.Set("abc")
                .ZipCode.Set("abc")
                .PersonalNumber.Click()
                .ValidationIcons[x => x.PersonalNumber].Should.BeVisible()
                .ValidationIcons[x => x.Email].Should.BeVisible()
                .ValidationIcons[x => x.PhoneNumber].Should.BeVisible()
                .ValidationIcons[x => x.ZipCode].Should.BeVisible()
                .PersonalNumber.Clear()
                .PersonalNumber.SetWithSpeed(TestDataService.PersonalNumberShort, 0.15)
                .Email.Set(TestDataService.Email)
                .PhoneNumber.Set(TestDataService.PhoneNumber)
                .ZipCode.Set(TestDataService.ZipCode)
                .ValidationIcons[x => x.PersonalNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.Email].Should.Not.BeVisible()
                .ValidationIcons[x => x.PhoneNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ZipCode].Should.Not.BeVisible();
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationSwish(Product[] products)
        {
            GoToPayexSwishPaymentFrame(products);
        }

        [Test]
        [Retry(3)]
        public void ValidateExceptionFromApi()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://api.externalintegration.payex.com") };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxxx");
            var swedbankPayClient = new SwedbankPayClient(httpClient);
            var payeeRef = DateTime.Now.Ticks.ToString();
            var amount = new Amount(1600);
            var vatAmount = new Amount(0);
            var phoneNumber = "+46739000001";
            var swishRequest = new SwishPaymentRequest(
                "Test Purchase", payeeRef, "GetUserAgent()", new Language("sv-SE"),
                new Urls(
                    new Uri("http://api.externalintegration.payex.com"),
                    new Uri("http://api.externalintegration.payex.com")),
                new PayeeInfo(Guid.NewGuid(), payeeRef),
                new PrefillInfo(new Msisdn(phoneNumber)));
            swishRequest.Payment.Prices.Add(new Price(amount, PriceType.Swish, vatAmount));
            swishRequest.Payment.Urls.HostUrls.Add(new Uri("http://api.externalintegration.payex.com"));
            var error = Assert.ThrowsAsync<HttpResponseException>(() => swedbankPayClient.Payments.SwishPayments.Create(swishRequest));

            Assert.AreEqual(1, error.Data.Keys.Count);
        }
    }
}