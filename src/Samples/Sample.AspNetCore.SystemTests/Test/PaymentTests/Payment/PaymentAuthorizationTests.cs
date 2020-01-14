using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentAuthorizationTests : Base.PaymentTests
    {
        public PaymentAuthorizationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Authorization(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = await SwedbankPayClient.PaymentOrder.Get(orderLink, SwedbankPay.Sdk.PaymentOrders.PaymentOrderExpand.All);

            // Global Order
            Assert.That(order.PaymentOrderResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrderResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrderResponse.State.Value, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreateCancellation], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State.Value,
                        Is.EqualTo(State.Completed));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(products.Count()));
            for (var i = 0; i < products.Count(); i++)
            {
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[i].Name, Is.EqualTo(products[i].Name));
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[i].UnitPrice.Value, Is.EqualTo(products[i].UnitPrice));
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[i].Quantity, Is.EqualTo(products[i].Quantity));
                Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[i].Amount.Value, Is.EqualTo(products[i].UnitPrice * products[i].Quantity));
            }
        }

    }
}
