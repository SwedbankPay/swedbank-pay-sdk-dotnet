﻿using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Validation
{
    [Ignore("Not needed")]
    public class ValidationTests : Base.PaymentTests
    {
        public ValidationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Ignore("Test failes due to external error")]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationCard(Product[] products)
        {
            Assert.DoesNotThrow(() => {

                GoToPayexCardPaymentFrame(products, null)
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
                .CardTypeSelector.Check()
                .ValidationIcons[x => x.CreditCardNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.Not.BeVisible();
            });
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationInvoice(Product[] products)
        {
            Assert.DoesNotThrow(() => {

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
            });
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationSwish(Product[] products)
        {
            GoToPayexSwishPaymentFrame(products);
        }
    }
}