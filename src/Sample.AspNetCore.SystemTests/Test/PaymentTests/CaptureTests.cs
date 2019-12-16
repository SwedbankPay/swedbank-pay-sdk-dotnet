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
    public class CaptureTests : PaymentTests
    {
        public CaptureTests(string driverAlias)
            : base(driverAlias)
        {
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task CapturePaymentMultipleProducts(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(OperationTypes.Capture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(OperationTypes.Reversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(OperationTypes.Get)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Capture").State,
                        Is.EqualTo("Completed"));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public async Task CapturePaymentSingleProduct(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo)
                .PaymentOrderLink.StoreValue(out var orderLink)
                .Actions.Rows[y => y.Name.Value.Contains(OperationTypes.Capture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(OperationTypes.Reversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(OperationTypes.Get)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Operations
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Cancel), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Capture), Is.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Get), Is.Not.Null);
            Assert.That(order.Operations.FirstOrDefault(x => x.Rel == OperationTypes.Reversal), Is.Not.Null);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Authorization").State,
                        Is.EqualTo("Completed"));
            Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == "Capture").State,
                        Is.EqualTo("Completed"));
        }
    }
}