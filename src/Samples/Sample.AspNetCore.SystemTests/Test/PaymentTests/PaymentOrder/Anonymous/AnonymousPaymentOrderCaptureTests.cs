using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Anonymous
{
    public class AnonymousPaymentOrderCaptureTests : Base.PaymentTests
    {
        public AnonymousPaymentOrderCaptureTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public void Anonymous_PaymentOrder_Card_Capture(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync(async () => {

                GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible();

                var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

                // Operations
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
                Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);

                // Transactions
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                            Is.EqualTo(State.Completed));
            });
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Invoice })]
        public void Anonymous_PaymentOrder_Invoice_Capture(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync(async () => {

                GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible();

                var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

                // Operations
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
                Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);

                // Transactions
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(3));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Initialization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                            Is.EqualTo(State.Completed));
            });
        }
    }
}
