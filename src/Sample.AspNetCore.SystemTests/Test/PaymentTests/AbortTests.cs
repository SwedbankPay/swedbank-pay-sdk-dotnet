using System.Threading.Tasks;

using Atata;

using Newtonsoft.Json;

using NUnit.Framework;

using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Api;
using Sample.AspNetCore.SystemTests.Test.Helpers;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class AbortTests : PaymentTests
    {
        public AbortTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public async Task AbortFlowPaymentSingleProduct(Product[] products)
        {
            GoToPaymentPage(products)
                .Abort.ClickAndGo()
                .Message.StoreValue(out var message)
                .Header.Products.ClickAndGo();

            var orderLink = message.Substring(message.IndexOf("/")).Replace(" has been Aborted", "");

            var order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Operations
            Assert.That(order.Operations, Is.Empty);

            order = JsonConvert.DeserializeObject<Order>(
                await this.HttpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment, Is.Null);
        }
    }
}