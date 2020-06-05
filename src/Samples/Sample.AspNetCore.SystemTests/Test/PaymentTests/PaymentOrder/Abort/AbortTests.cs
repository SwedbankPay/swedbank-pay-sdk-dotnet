using System;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Abort
{
    public class AbortTests : Base.PaymentTests
    {
        public AbortTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public async Task Abort_PaymentOrder(Product[] products)
        {
            GoToPayexPaymentPage(products)
                .Abort.ClickAndGo()
                .Message.StoreValue(out var message)
                .Header.Products.ClickAndGo();

            var orderLink = message.OriginalString.Substring(message.OriginalString.IndexOf("/")).Replace(" has been Aborted", "");

            var order = await SwedbankPayClient.PaymentOrders.Get(new Uri(orderLink, UriKind.RelativeOrAbsolute), SwedbankPay.Sdk.PaymentOrders.PaymentOrderExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.AbortedPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentOrderResponse.CurrentPayment.Payment, Is.Null);
        }
    }
}