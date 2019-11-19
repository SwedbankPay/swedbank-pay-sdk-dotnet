namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Sample.AspNetCore.SystemTests.Services;
    using Sample.AspNetCore.SystemTests.Test.Api;
    using Sample.AspNetCore.SystemTests.Test.Helpers;
    using System.Linq;
    using Atata;
    using System.Threading.Tasks;

    public class ReversalTests : PaymentTests
    {
        public ReversalTests(string driverAlias) : base(driverAlias) { }

        #region Reversal

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task ReversalCapture_Payment_Single_Product(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Capture].ExecuteAction.ClickAndGo()
                .Actions.Rows[x => x.Name.Value.Trim() == OperationTypes.Reversal].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(3));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State, Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Capture").State, Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Reversal").State, Is.EqualTo("Completed"));
        }

        [Test, TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task ReversalCapture_Payment_Multiple_Products(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink).Actions
                .Rows[x => x.Name.Value.Trim() == OperationTypes.Capture].ExecuteAction
                .ClickAndGo().Actions
                .Rows[x => x.Name.Value.Trim() == OperationTypes.Reversal].ExecuteAction
                .ClickAndGo().Actions
                .Rows[y => y.Name.Value.Trim() == OperationTypes.Get].Should
                .BeVisible().Actions.Rows.Count.Should
                .Equal(1);

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(3));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State, Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Capture").State, Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Reversal").State, Is.EqualTo("Completed"));
        }

        #endregion
    }
}
