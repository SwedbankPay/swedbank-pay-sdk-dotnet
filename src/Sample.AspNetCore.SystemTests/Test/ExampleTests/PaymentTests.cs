using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels;
using System.Collections.Generic;
using System.Collections;
using Sample.AspNetCore.SystemTests.Test.Helpers;

namespace Sample.AspNetCore.SystemTests.Test.ExampleTests
{
    public class PaymentTests : TestBase
    {
        public PaymentTests(string driverAlias) : base(driverAlias) { }

        #region Method Helpers

        private PaymentFramePage GoToPaymentPage(KeyValuePair<string, int>[] keyValuePairs)
        {
            var page = Go.To<ProductsPage>();

            foreach(var keyValuePair in keyValuePairs)
            {
                page.Products.List[x => x.Name == keyValuePair.Key].AddToCart.Click();
                page.Cart.Products[x => x.Name == keyValuePair.Key].Quantity.Set(keyValuePair.Value.ToString());
            }

            return page.Checkout.ClickAndGo();   
        }

        public class TestDataSingleProduct : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(Products.Product1, 1)
                };
            }
        }

        public class TestDataMultipleProducts : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(Products.Product1, 3),
                    new KeyValuePair<string, int>(Products.Product2, 2),
                };
            }
        }

        #endregion

        #region Components


        #endregion

        #region Validation

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void Field_Validation(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        #endregion

        #region Flow

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void Anonymous_Flow_Payment(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void Normal_Flow_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataMultipleProducts))]
        public void Normal_Flow_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void Cancellation_Flow_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void Rejected_Flow_Payment(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void Capture_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataMultipleProducts))]
        public void Capture_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataSingleProduct))]
        public void ReversalCapture_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        [Test, TestCaseSource(typeof(TestDataMultipleProducts))]
        public void ReversalCapture_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs);
        }

        #endregion
    }
}
