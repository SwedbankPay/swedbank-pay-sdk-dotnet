using Atata;
using Newtonsoft.Json;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Api;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class AbortTests : PaymentTests
    {
        public AbortTests(string driverAlias) : base(driverAlias) { }

        #region Abort

        [Test, TestCaseSource(nameof(TestData), new object[] { true, null })]
        public async Task Abort_Flow_Payment_Single_Product(Product[] products)
        {
            GoToPaymentPage(products)
                .Abort.ClickAndGo()
                .Message.StoreValue(out string message)
                .Header.Products.ClickAndGo();

            var orderLink = message.Substring(message.IndexOf("/")).Replace(" has been Aborted", "");

            var order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink, ExpandParameter.Transactions));

            // Operations
            Assert.That(order.Operations, Is.Empty);

            order = JsonConvert.DeserializeObject<Order>(await _httpClientService.SendGetRequest(orderLink, ExpandParameter.CurrentPayment));

            // Transactions
            Assert.That(order.PaymentOrder.CurrentPayment.Payment, Is.Null);

        }

        #endregion
    }
}
