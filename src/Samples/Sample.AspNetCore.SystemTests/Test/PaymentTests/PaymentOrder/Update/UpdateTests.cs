using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Linq;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Update;

public class UpdateTests : Base.PaymentTests
{
    public UpdateTests(string driverAlias)
        : base(driverAlias)
    {
    }


    [Test]
    [Retry(2)]
    [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
    public void Update_PaymentOrder(Product[] products, PayexInfo payexInfo)
    {
        Assert.DoesNotThrowAsync( async () => {

            GoToPayexSwishPaymentFrame(products.Skip(1).ToArray())
            .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Skip(1).First().UnitPrice / 100 * products.Skip(1).First().Quantity))} kr")
            .SwitchToRoot<HomePage>()
            .Header.Products.ClickAndGo();

            GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
            .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].IsVisible, 60, 10)
            .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
            .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
            .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
            .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Clear.ClickAndGo();

            await SwedbankPayClient.PaymentOrders.Get(_link, PaymentOrderExpand.All);
        });
    }
}