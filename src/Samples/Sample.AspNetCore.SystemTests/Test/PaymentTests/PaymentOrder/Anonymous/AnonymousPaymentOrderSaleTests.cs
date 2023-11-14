using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrder;
using System.Linq;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Anonymous
{
    public class AnonymousPaymentOrderSaleTests : Base.PaymentTests
    {
        public AnonymousPaymentOrderSaleTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public void Anonymous_PaymentOrder_Swish_Sale(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync( async () => {

                GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
                    .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.Reversal)].IsVisible, 60, 10)
                    .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.Reversal)].Should.BeVisible()
                    // .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                    .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Clear.ClickAndGo();

                var order = await SwedbankPayClient.PaymentOrders.Get(_link, PaymentOrderExpand.All);

                // Global Order
                Assert.That(order.PaymentOrder.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
                Assert.That(order.PaymentOrder.Currency.ToString(), Is.EqualTo("SEK"));
                // Assert.That(order.PaymentOrder.Status, Is.EqualTo(Status.Ready));

                // Operations
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
                Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);
                
                
                Assert.That(order.PaymentOrder.Paid?.Details, Is.Not.Null);

                // Transactions
                // Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
                // Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                //             Is.EqualTo(State.Completed));

                // Order Items
                Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(products.Count()));
                for (var i = 0; i < products.Count(); i++)
                {
                    Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Name, Is.EqualTo(products[i].Name));
                    Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).UnitPrice.InLowestMonetaryUnit, Is.EqualTo(products[i].UnitPrice));
                    Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Quantity, Is.EqualTo(products[i].Quantity));
                    Assert.That(order.PaymentOrder.OrderItems.OrderItemList.ElementAt(i).Amount.InLowestMonetaryUnit, Is.EqualTo(products[i].UnitPrice * products[i].Quantity));
                }
            });
        }
    }
}
