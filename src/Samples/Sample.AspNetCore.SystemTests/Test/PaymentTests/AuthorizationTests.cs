using System.Linq;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class AuthorizationTests : Base.PaymentTests
    {
        public AuthorizationTests(string driverAlias)
            : base(driverAlias)
        {
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task AnonymousFlowPaymentMultipleProductsCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
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
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo(State.Completed));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(2));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].UnitPrice.Value, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Amount.Value, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].Name, Is.EqualTo(products[1].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].UnitPrice.Value, Is.EqualTo(products[1].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].Quantity, Is.EqualTo(products[1].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].Amount.Value, Is.EqualTo(products[1].UnitPrice * products[1].Quantity));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task AnonymousFlowPaymentSingleProductCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
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
                        Is.EqualTo("Completed"));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(1));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].UnitPrice.Value, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Amount.Value, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Invoice })]
        public async Task AnonymousFlowPaymentSingleProductInvoice(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
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
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Initialization").State.Value,
                        Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State.Value,
                        Is.EqualTo("Completed"));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(1));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].UnitPrice.Value, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Amount.Value, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task NormalFlowPaymentMultipleProductsCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
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
                        Is.EqualTo("Completed"));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(2));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].UnitPrice.Value, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Amount.Value, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].Name, Is.EqualTo(products[1].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].UnitPrice.Value, Is.EqualTo(products[1].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].Quantity, Is.EqualTo(products[1].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[1].Amount.Value, Is.EqualTo(products[1].UnitPrice * products[1].Quantity));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task NormalFlowPaymentSingleProductCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
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
                        Is.EqualTo("Completed"));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(1));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].UnitPrice.Value, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Amount.Value, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Swish })]
        public async Task NormalFlowPaymentSingleProductSwish(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = await SwedbankPayClient.PaymentOrder.Get(orderLink, SwedbankPay.Sdk.PaymentOrders.PaymentOrderExpand.All);

            // Global Order
            Assert.That(order.PaymentOrderResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrderResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrderResponse.State.Value, Is.EqualTo("Ready"));

            // Operations
            // Operations
            Assert.That(order.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Not.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Sale").State.Value,
                        Is.EqualTo("Completed"));

            // Order Items
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList.Count, Is.EqualTo(1));

            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].UnitPrice.Value, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrderResponse.OrderItems.OrderItemList[0].Amount.Value, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task NormalFlowPaymentSingleProductLocalMenuCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var cardPayment = await SwedbankPayClient.Payment.GetCreditCardPayment(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Global Order
            Assert.That(cardPayment.PaymentResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(cardPayment.PaymentResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(cardPayment.PaymentResponse.State.Value, Is.EqualTo("Ready"));

            // Operations
            Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCancellation], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCapture], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Authorization").State.Value,
                        Is.EqualTo("Completed"));
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Swish })]
        public async Task NormalFlowPaymentSingleProductLocalMenuSwish(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var swishPayment = await SwedbankPayClient.Payment.GetSwishPayment(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Global Order
            Assert.That(swishPayment.PaymentResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(swishPayment.PaymentResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(swishPayment.PaymentResponse.State.Value, Is.EqualTo("Ready"));

            // Operations
            Assert.That(swishPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);
            Assert.That(swishPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Sale").State.Value,
                        Is.EqualTo("Completed"));
        }

    }
}