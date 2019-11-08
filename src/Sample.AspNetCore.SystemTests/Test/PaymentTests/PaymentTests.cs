using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels;
using System.Collections.Generic;
using System.Collections;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using Sample.AspNetCore.SystemTests.PageObjectModels.Payment;
using OpenQA.Selenium;
using System;
using Sample.AspNetCore.SystemTests.Services;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class PaymentTests : TestBase
    {
        public PaymentTests(string driverAlias) : base(driverAlias) { }

        #region TestData

        static IEnumerable TestData(bool singleProduct = true, string paymentMethod = PaymentMethods.Card)
        {
            List<object> data = new List<object>();

            if (singleProduct)
            {
                data.Add(new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(Products.Product1, 2)
                });
            }
            else
            {
                data.Add(new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(Products.Product1, 3),
                    new KeyValuePair<string, int>(Products.Product2, 2),
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

        #endregion

        #region Method Helpers

        private PaymentPage GoToPaymentPage(KeyValuePair<string, int>[] keyValuePairs)
        {
            var page = Go.To<ProductsPage>();

            foreach (var keyValuePair in keyValuePairs)
            {
                page.Products.Rows[x => x.Name == keyValuePair.Key].AddToCart.Click();
                //page.CartProducts.Rows[x => x.Name == keyValuePair.Key].Quantity.Set(keyValuePair.Value.ToString());
                page.CartProducts.Rows[x => x.Name == keyValuePair.Key].Update.Click();
            }

            return page.Checkout.ClickAndGo();
        }

        private PayexCardFramePage GoToPayexCardPaymentFrame(KeyValuePair<string, int>[] keyValuePairs)
        {
            return GoToPaymentPage(keyValuePairs)
                .PaymentMethodsFrame.SwitchTo()
                .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexCardFramePage>();
        }

        private PayexSwishFramePage GoToPayexSwishPaymentFrame(KeyValuePair<string, int>[] keyValuePairs)
        {
            return GoToPaymentPage(keyValuePairs)
                .PaymentMethodsFrame.SwitchTo()
                .PaymentMethods[x => x.Name == PaymentMethods.Swish].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Swish].PaymentFrame.SwitchTo<PayexSwishFramePage>();
        }

        private PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(KeyValuePair<string, int>[] keyValuePairs)
        {
            return GoToPaymentPage(keyValuePairs)
                .PaymentMethodsFrame.SwitchTo()
                .PaymentMethods[x => x.Name == PaymentMethods.Invoice].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Invoice].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
        }

        private ValidationPage PayWithPayexCard(KeyValuePair<string, int>[] keyValuePairs, PayexCardInfo info)
        {
            return GoToPayexCardPaymentFrame(keyValuePairs)
                .CreditCardNumber.Set(info.CreditCardNumber)
                .ExpiryDate.Set(info.ExpiryDate)
                .Cvc.Set(info.Cvc)
                .Pay.ClickAndGo();
        }

        private ValidationPage PayWithPayexSwish(KeyValuePair<string, int>[] keyValuePairs, PayexSwishInfo info)
        {
            return GoToPayexSwishPaymentFrame(keyValuePairs)
                .SwishNumber.Set(info.SwishNumber)
                .Pay.ClickAndGo();
        }

        private ValidationPage PayWithPayexInvoice(KeyValuePair<string, int>[] keyValuePairs, PayexInvoiceInfo info)
        {
            return GoToPayexInvoicePaymentFrame(keyValuePairs)
                .PersonalNumber.Set(info.PersonalNumber)
                .Email.Set(info.Email)
                .PhoneNumber.Set(info.PhoneNumber)
                .ZipCode.Set(info.ZipCode)
                .Next.ClickAndGo();
        }

        private ValidationPage GoToValidationPage(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            switch (payexInfo)
            {
                case PayexCardInfo cardInfo:

                    return PayWithPayexCard(keyValuePairs, cardInfo);

                case PayexSwishInfo swishInfo:

                    return PayWithPayexSwish(keyValuePairs, swishInfo);

                case PayexInvoiceInfo invoiceInfo:

                    return PayWithPayexInvoice(keyValuePairs, invoiceInfo);
            }

            return null;
        }

        #endregion

        #region Validation

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void Field_Validation_Card(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPayexCardPaymentFrame(keyValuePairs)
                .CreditCardNumber.Set("abc")
                .ExpiryDate.Set("abcd")
                .Cvc.Set("abc")
                .CreditCardNumber.Click()
                .ValidationIcons[x => x.CreditCardNumber].Should.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.BeVisible()
                .CreditCardNumber.Set(TestDataService.CreditCardNumber)
                .ExpiryDate.Set(TestDataService.CreditCardExpiratioDate)
                .Cvc.Set(TestDataService.CreditCardCVC)
                .ValidationIcons[x => x.CreditCardNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.Not.BeVisible();
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void Field_Validation_Swish(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPayexSwishPaymentFrame(keyValuePairs);
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void Field_Validation_Invoice(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPayexInvoicePaymentFrame(keyValuePairs)
                .PersonalNumber.Set("abc")
                .Email.Set("abc")
                .PhoneNumber.Set("abc")
                .ZipCode.Set("abc")
                .PersonalNumber.Click()
                .ValidationIcons[x => x.PersonalNumber].Should.BeVisible()
                .ValidationIcons[x => x.Email].Should.BeVisible()
                .ValidationIcons[x => x.PhoneNumber].Should.BeVisible()
                .ValidationIcons[x => x.ZipCode].Should.BeVisible()
                .PersonalNumber.Set(TestDataService.PersonalNumberShort)
                .Email.Set(TestDataService.Email)
                .PhoneNumber.Set(TestDataService.PhoneNumber)
                .ZipCode.Set(TestDataService.ZipCode)
                .ValidationIcons[x => x.PersonalNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.Email].Should.Not.BeVisible()
                .ValidationIcons[x => x.PhoneNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ZipCode].Should.Not.BeVisible();
        }

        #endregion

        #region Success

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public void Anonymous_Flow_Payment_Card(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToValidationPage(keyValuePairs, payexInfo);
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Normal_Flow_Payment_Single_Product_Card(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Normal_Flow_Payment_Multiple_Products_Card(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Normal_Flow_Payment_Single_Product_Swish(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Normal_Flow_Payment_Single_Product_Invoice(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        #endregion

        #region Rejection

        [Test, TestCaseSource(nameof(TestData))]
        public void Rejected_Flow_Payment(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        #endregion

        #region Cancellation

        [Test, TestCaseSource(nameof(TestData))]
        public void Cancellation_Flow_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        #endregion

        #region Capture

        [Test, TestCaseSource(nameof(TestData))]
        public void Capture_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Capture_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        #endregion

        #region Reversal

        [Test, TestCaseSource(nameof(TestData))]
        public void ReversalCapture_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        [Test, TestCaseSource(nameof(TestData))]
        public void ReversalCapture_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs)
        {

        }

        #endregion

    }
}
