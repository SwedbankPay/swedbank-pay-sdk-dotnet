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

namespace Sample.AspNetCore.SystemTests.Test.ExampleTests
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
                    new KeyValuePair<string, int>(Products.Product1, 3),
                    new KeyValuePair<string, int>(Products.Product2, 2),
                });
            }
            else
            {
                data.Add(new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(Products.Product1, 1)
                });
            }

            switch(paymentMethod)
            {
                case PaymentMethods.Card:
                    data.Add(new PayexCardInfo("", "", ""));
                    break;


                case PaymentMethods.Swish:
                    data.Add(new PayexSwishInfo(""));
                    break;


                case PaymentMethods.Invoice:
                    data.Add(new PayexInvoiceInfo("", "", "", ""));
                    break;
            }

            return data.ToArray();
        }

        #endregion

        #region Method Helpers

        private PaymentPage GoToPaymentPage(KeyValuePair<string, int>[] keyValuePairs)
        {
            var page = Go.To<ProductsPage>();

            foreach(var keyValuePair in keyValuePairs)
            {
                page.Products.List[x => x.Name == keyValuePair.Key].AddToCart.Click();
                page.Cart.Products[x => x.Name == keyValuePair.Key].Quantity.Set(keyValuePair.Value.ToString());
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
                .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexSwishFramePage>();
        }

        private PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(KeyValuePair<string, int>[] keyValuePairs)
        {
            return GoToPaymentPage(keyValuePairs)
                .PaymentMethodsFrame.SwitchTo()
                .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
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
            GoToPayexCardPaymentFrame(keyValuePairs);
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void Field_Validation_Swish(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPayexSwishPaymentFrame(keyValuePairs);
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void Field_Validation_Invoice(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPayexInvoicePaymentFrame(keyValuePairs);
        }

        #endregion

        #region Success

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public void Anonymous_Flow_Payment_Card(KeyValuePair<string, int>[] keyValuePairs)
        {

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
