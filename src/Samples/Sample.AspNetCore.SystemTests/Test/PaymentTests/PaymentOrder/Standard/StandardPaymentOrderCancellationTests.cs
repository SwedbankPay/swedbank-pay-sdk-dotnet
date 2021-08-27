using System.Linq;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Standard
{
    public class StandardPaymentOrderCancellationTests : Base.PaymentTests
    {
        public StandardPaymentOrderCancellationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public void Standard_PaymentOrder_Card_Cancellation(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync(async () => {

                GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].ExecuteAction.ClickAndGo()
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible();

                var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

                // Operations
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
                Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

                // Transactions
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Cancellation).State,
                            Is.EqualTo(State.Completed));
            });
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Invoice })]
        public void Standard_PaymentOrder_Invoice_Cancellation(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync(async () => {

                GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].ExecuteAction.ClickAndGo()
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible();

                var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

                // Operations
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
                Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

                // Transactions
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(3));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Initialization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Cancellation).State,
                            Is.EqualTo(State.Completed));
            });
        }
    }
}
