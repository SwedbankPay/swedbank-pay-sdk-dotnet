using System;

using Atata;

using NUnit.Framework;

using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;

using SwedbankPay.Sdk.PaymentOrder;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Abort;

public class AbortTests : Base.PaymentTests
{
    public AbortTests(string driverAlias)
        : base(driverAlias)
    {
    }


    [Test]
    [Retry(2)]
    [TestCaseSource(nameof(TestData), new object[] { true, null })]
    public void Abort_PaymentOrder(Product[] products)
    {
        Assert.DoesNotThrowAsync(async () => {

            GoToPayexPaymentPage(products)
                .Abort.ClickAndGo()
                .Message.StoreValueAsUri(out var message)
                .Header.Products.ClickAndGo();

            var orderLink = message.OriginalString.Substring(message.OriginalString.IndexOf("/")).Replace(" has been Aborted", "");

            var order = await SwedbankPayClient.PaymentOrders.Get(new Uri(orderLink, UriKind.RelativeOrAbsolute), PaymentOrderExpand.All);

            Assert.NotNull(order);
            Assert.NotNull(order.PaymentOrder);
            Assert.NotNull(order.PaymentOrder.Aborted);
            Assert.That(order.PaymentOrder.Aborted.AbortReason, Is.EqualTo("CanceledByUser"));

            // Transactions
            Assert.That(order.PaymentOrder.Paid?.Details, Is.Null);
        });
    }
}