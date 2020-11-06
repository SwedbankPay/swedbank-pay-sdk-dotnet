using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Standard
{
    public class StandardPaymentOrderAuthorizationTests : Base.PaymentTests
    {
        public StandardPaymentOrderAuthorizationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Standard_PaymentOrder_Card_Authorization(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

            // Global Order
            Assert.That(order.PaymentOrder.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreateCancellation], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(products.Count()));
            for (var i = 0; i < products.Count(); i++)
            {
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Name, Is.EqualTo(products[i].Name));
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).UnitPrice.InLowestMonetaryUnit, Is.EqualTo(products[i].UnitPrice));
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Quantity, Is.EqualTo(products[i].Quantity));
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Amount.InLowestMonetaryUnit, Is.EqualTo(products[i].UnitPrice * products[i].Quantity));
            }
        }


        [Test]
        [Retry(5)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Invoice })]
        public async Task Standard_PaymentOrder_Invoice_Authorization(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);

            // Global Order
            Assert.That(order.PaymentOrder.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreateCancellation], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Initialization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(products.Count()));
            for (var i = 0; i < products.Count(); i++)
            {
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Name, Is.EqualTo(products[i].Name));
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).UnitPrice.InLowestMonetaryUnit, Is.EqualTo(products[i].UnitPrice));
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Quantity, Is.EqualTo(products[i].Quantity));
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Amount.InLowestMonetaryUnit, Is.EqualTo(products[i].UnitPrice * products[i].Quantity));
            }
        }

    }
}
