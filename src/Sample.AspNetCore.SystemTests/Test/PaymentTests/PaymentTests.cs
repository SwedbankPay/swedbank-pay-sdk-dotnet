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

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class PaymentTests : TestBase
    {
        private HttpClientService _httpClientService;
        private string _orderAmount;

        public PaymentTests(string driverAlias) : base(driverAlias) { }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _httpClientService = new HttpClientService();
        }

        #region TestData

        static IEnumerable TestData(bool singleProduct = true, string paymentMethod = PaymentMethods.Card)
        {
            List<object> data = new List<object>();

            if (singleProduct)
            {
                data.Add(new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(Products.Product1, 1)
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

        private PaymentPage GoToPaymentPage(KeyValuePair<string, int>[] keyValuePairs, bool standardCheckout = false)
        {
            var page = Go.To<ProductsPage>();

            if (page.Header.ClearOrders.Exists(new SearchOptions { Timeout = new TimeSpan(0, 0, 0, 0, 500), IsSafely = true }))
            {
                page
                .Header.ClearOrders.Click()
                .Header.Products.Click();
            }

            foreach (var keyValuePair in keyValuePairs)
            {
                page.Products.Rows[x => x.Name == keyValuePair.Key].AddToCart.Click();

                if(keyValuePair.Value != 1)
                {
                    page
                    .CartProducts.Rows[x => x.Name == keyValuePair.Key].Quantity.Set(keyValuePair.Value)
                    .CartProducts.Rows[x => x.Name == keyValuePair.Key].Update.Click();
                }
            }

            var temp = page.TotalAmount.Value;
            _orderAmount = temp.Substring(0, temp.IndexOf(",")).Replace(" ", "") + "00";

            return standardCheckout 
                ? page.StandardCheckout.ClickAndGo()
                : page.Checkout.ClickAndGo();
        }

        private PaymentFramePage GoToPaymentFramePage(KeyValuePair<string, int>[] keyValuePairs, bool standardCheckout = false)
        {
            return standardCheckout
                ? GoToPaymentPage(keyValuePairs, standardCheckout)
                    .IdentificationFrame.SwitchTo()
                    .Email.Set(TestDataService.Email)
                    .PhoneNumber.Set(TestDataService.SwedishPhoneNumber)
                    .Next.Click().SwitchToRoot<PaymentPage>()
                    .PaymentMethodsFrame.SwitchTo()
                : GoToPaymentPage(keyValuePairs, standardCheckout)
                    .PaymentMethodsFrame.SwitchTo();
        }

        private PayexCardFramePage GoToPayexCardPaymentFrame(KeyValuePair<string, int>[] keyValuePairs, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(keyValuePairs, standardCheckout)
                    .PaymentMethods[x => x.Name == PaymentMethods.Card].Click()
                    .PaymentMethods[x => x.Name == PaymentMethods.Card].PaymentFrame.SwitchTo<PayexCardFramePage>();
        }

        private PayexSwishFramePage GoToPayexSwishPaymentFrame(KeyValuePair<string, int>[] keyValuePairs, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(keyValuePairs, standardCheckout)
                    .PaymentMethods[x => x.Name == PaymentMethods.Swish].Click()
                    .PaymentMethods[x => x.Name == PaymentMethods.Swish].PaymentFrame.SwitchTo<PayexSwishFramePage>();
        }

        private PayexInvoiceFramePage GoToPayexInvoicePaymentFrame(KeyValuePair<string, int>[] keyValuePairs, bool standardCheckout = false)
        {
            return GoToPaymentFramePage(keyValuePairs, standardCheckout)
                    .PaymentMethods[x => x.Name == PaymentMethods.Invoice].Click()
                    .PaymentMethods[x => x.Name == PaymentMethods.Invoice].PaymentFrame.SwitchTo<PayexInvoiceFramePage>();
        }

        private ThankYouPage PayWithPayexCard(KeyValuePair<string, int>[] keyValuePairs, PayexCardInfo info, bool standardCheckout = false)
        {
            return standardCheckout
                ? GoToPayexCardPaymentFrame(keyValuePairs, standardCheckout)
                    .Cvc.Set(info.Cvc)
                    .Pay.ClickAndGo()
                : GoToPayexCardPaymentFrame(keyValuePairs, standardCheckout)
                    .CreditCardNumber.Set(info.CreditCardNumber)
                    .ExpiryDate.Set(info.ExpiryDate)
                    .Cvc.Set(info.Cvc)
                    .Pay.ClickAndGo();
        }

        private ThankYouPage PayWithPayexSwish(KeyValuePair<string, int>[] keyValuePairs, PayexSwishInfo info, bool standardCheckout = false)
        {
            return GoToPayexSwishPaymentFrame(keyValuePairs, standardCheckout)
                .SwishNumber.Set(info.SwishNumber)
                .Pay.ClickAndGo();
        }

        private ThankYouPage PayWithPayexInvoice(KeyValuePair<string, int>[] keyValuePairs, PayexInvoiceInfo info, bool standardCheckout = false)
        {
            return GoToPayexInvoicePaymentFrame(keyValuePairs, standardCheckout)
                .PersonalNumber.Set(info.PersonalNumber)
                .Email.Set(info.Email)
                .PhoneNumber.Set(info.PhoneNumber)
                .ZipCode.Set(info.ZipCode)
                .Next.Click()
                .Pay.ClickAndGo();
        }

        private OrdersPage GoToOrdersPage(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo, bool standardCheckout = false)
        {
            switch (payexInfo)
            {
                case PayexCardInfo cardInfo:

                    return PayWithPayexCard(keyValuePairs, cardInfo, standardCheckout).Header.Orders.ClickAndGo();

                case PayexSwishInfo swishInfo:

                    return PayWithPayexSwish(keyValuePairs, swishInfo, standardCheckout).Header.Orders.ClickAndGo();

                case PayexInvoiceInfo invoiceInfo:

                    return PayWithPayexInvoice(keyValuePairs, invoiceInfo, standardCheckout).Header.Orders.ClickAndGo();
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
        public async Task Anonymous_Flow_Payment_Single_Product_Card(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Cancel));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Capture));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));

            Assert.That(order.PaymentOrder.Id, Is.EqualTo(orderLink));
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(_orderAmount));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));
            Assert.That(order.PaymentOrder.Operation, Is.EqualTo("Purchase"));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Anonymous_Flow_Payment_Multiple_Products_Card(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Cancel));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Capture));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));

            Assert.That(order.PaymentOrder.Id, Is.EqualTo(orderLink));
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(_orderAmount.Replace(" ", "")));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));
            Assert.That(order.PaymentOrder.Operation, Is.EqualTo("Purchase"));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task Normal_Flow_Payment_Single_Product_Card(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo, standardCheckout: true)
                 .PaymentOrderLink.StoreValue(out string orderLink)
                 .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                 .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                 .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                 .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Cancel));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Capture));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));

            Assert.That(order.PaymentOrder.Id, Is.EqualTo(orderLink));
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(_orderAmount));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));
            Assert.That(order.PaymentOrder.Operation, Is.EqualTo("Purchase"));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public void Normal_Flow_Payment_Multiple_Products_Card(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {

        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Swish })]
        public void Normal_Flow_Payment_Single_Product_Swish(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {

        }

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Invoice })]
        public async Task Anonymous_Flow_Payment_Single_Product_Invoice(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Cancel));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Capture));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));

            Assert.That(order.PaymentOrder.Id, Is.EqualTo(orderLink));
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(_orderAmount));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));
            Assert.That(order.PaymentOrder.Operation, Is.EqualTo("Purchase"));
        }

        #endregion

        #region Rejection

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public void Rejected_Flow_Payment(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {

        }

        #endregion

        #region Abort

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public async Task Abort_Flow_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs)
        {
            GoToPaymentPage(keyValuePairs)
                .Abort.ClickAndGo()
                .Message.StoreValue(out string message)
                .Header.Orders.ClickAndGo();

            var orderLink = message.Substring(message.IndexOf("/")).Replace(" has been Aborted", "");
            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsEmpty(order.Operations);

            Assert.That(order.PaymentOrder.Id, Is.EqualTo(orderLink));
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(_orderAmount));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Aborted"));
            Assert.That(order.PaymentOrder.Operation, Is.EqualTo("Purchase"));
        }

        #endregion

        #region Cancellation

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task Cancellation_Flow_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Cancel].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Cancellation_Flow_Payment_Multiple_Product(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Cancel].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));
        }

        #endregion

        #region Capture

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task Capture_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Capture].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Reversal].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Reversal));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Capture_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Capture].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Reversal].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));
            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Reversal));
        }

        #endregion

        #region Reversal

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task ReversalCapture_Payment_Single_Product(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Capture].ExecuteAction.ClickAndGo()
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Reversal].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task ReversalCapture_Payment_Multiple_Products(KeyValuePair<string, int>[] keyValuePairs, PayexInfo payexInfo)
        {
            GoToOrdersPage(keyValuePairs, payexInfo)
                .PaymentOrderLink.StoreValue(out string orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Capture].ExecuteAction.ClickAndGo()
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Reversal].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink));

            Assert.IsNotNull(order.Operations.First(y => y.Rel == OperationTypes.Get));
        }

        #endregion

    }
}
