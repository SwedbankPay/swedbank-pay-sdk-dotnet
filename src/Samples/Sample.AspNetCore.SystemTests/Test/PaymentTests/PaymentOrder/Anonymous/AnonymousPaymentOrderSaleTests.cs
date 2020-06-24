using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Anonymous
{
    public class AnonymousPaymentOrderSaleTests : Base.PaymentTests
    {
        public AnonymousPaymentOrderSaleTests(string driverAlias)
            : base()
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Anonymous_PaymentOrder_Swish_Sale(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = await SwedbankPayClient.PaymentOrders.Get(orderLink, SwedbankPay.Sdk.PaymentOrders.PaymentOrderExpand.All);

            // Global Order
            Assert.That(order.PaymentOrderResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrderResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrderResponse.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(order.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                        Is.EqualTo(State.Completed));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(products.Count()));
            for (var i = 0; i < products.Count(); i++)
            {
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.ElementAt(i).Name, Is.EqualTo(products[i].Name));
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.ElementAt(i).UnitPrice.Value, Is.EqualTo(products[i].UnitPrice));
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.ElementAt(i).Quantity, Is.EqualTo(products[i].Quantity));
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.ElementAt(i).Amount.Value, Is.EqualTo(products[i].UnitPrice * products[i].Quantity));
            }
        }

    }
}
