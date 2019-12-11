using System.Linq;
using System.Threading.Tasks;

using Atata;

using Newtonsoft.Json;

using NUnit.Framework;

using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Api;
using Sample.AspNetCore.SystemTests.Test.Helpers;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class AuthorizationTests : PaymentTests
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
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Global Order
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.OrderItems));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(2));

            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].UnitPrice, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Amount, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));

            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].Name, Is.EqualTo(products[1].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].UnitPrice, Is.EqualTo(products[1].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].Quantity, Is.EqualTo(products[1].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].Amount, Is.EqualTo(products[1].UnitPrice * products[1].Quantity));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task AnonymousFlowPaymentSingleProductCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Global Order
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.OrderItems));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].UnitPrice, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Amount, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Invoice })]
        public async Task AnonymousFlowPaymentSingleProductInvoice(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Global Order
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Initialization").State,
                        Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.OrderItems));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(1));

            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].UnitPrice, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Amount, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task NormalFlowPaymentMultipleProductsCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, true)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Global Order
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.OrderItems));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(2));

            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].UnitPrice, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Amount, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));

            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].Name, Is.EqualTo(products[1].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].UnitPrice, Is.EqualTo(products[1].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].Quantity, Is.EqualTo(products[1].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[1].Amount, Is.EqualTo(products[1].UnitPrice * products[1].Quantity));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task NormalFlowPaymentSingleProductCard(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, true)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Cancel].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Capture].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Global Order
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.OrderItems));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].UnitPrice, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Amount, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Swish })]
        public async Task NormalFlowPaymentSingleProductSwish(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, true)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Reversal].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Global Order
            Assert.That(order.PaymentOrder.Amount, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(order.PaymentOrder.Currency, Is.EqualTo("SEK"));
            Assert.That(order.PaymentOrder.State, Is.EqualTo("Ready"));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Sale").State,
                        Is.EqualTo("Completed"));

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.OrderItems));

            // Order Items
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList.Count, Is.EqualTo(1));

            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].UnitPrice, Is.EqualTo(products[0].UnitPrice));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Quantity, Is.EqualTo(products[0].Quantity));
            Assert.That(order.PaymentOrder.OrderItems.OrderItemList[0].Amount, Is.EqualTo(products[0].UnitPrice * products[0].Quantity));
        }
    }
}