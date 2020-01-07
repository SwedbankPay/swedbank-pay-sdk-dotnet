using System.Linq;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class CaptureTests : Base.PaymentTests
    {
        public CaptureTests(string driverAlias)
            : base(driverAlias)
        {
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task CapturePaymentMultipleProducts(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = await SwedbankPayClient.PaymentOrder.Get(orderLink, SwedbankPay.Sdk.PaymentOrders.PaymentOrderExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrderResponse.CurrentPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Authorization").State.Value,
                        Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Capture").State.Value,
                        Is.EqualTo("Completed"));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task CapturePaymentSingleProduct(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = await SwedbankPayClient.PaymentOrder.Get(orderLink, SwedbankPay.Sdk.PaymentOrders.PaymentOrderExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrderResponse.CurrentPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Authorization").State.Value,
                        Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Capture").State.Value,
                        Is.EqualTo("Completed"));
        }
    }
}