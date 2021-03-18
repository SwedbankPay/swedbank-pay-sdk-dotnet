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
    public class StandardPaymentOrderReversalTests : Base.PaymentTests
    {
        public StandardPaymentOrderReversalTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Standard_PaymentOrder_Card_Reversal(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(3));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State,
                        Is.EqualTo(State.Completed));
        }


        [Test]
        [Retry(5)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Standard_PaymentOrder_Swish_Reversal(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);
            var counter = 0;

            while (order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State != State.Completed && counter <= 15)
            {
                await Task.Delay(1000).ConfigureAwait(false);
                try
                {
                    order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);
                }
                catch { }
                counter++;
            }

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State,
                        Is.EqualTo(State.Completed));
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Invoice })]
        public async Task Standard_PaymentOrder_Invoice_Reversal(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(4));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Initialization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State,
                        Is.EqualTo(State.Completed));
        }

    }
}
