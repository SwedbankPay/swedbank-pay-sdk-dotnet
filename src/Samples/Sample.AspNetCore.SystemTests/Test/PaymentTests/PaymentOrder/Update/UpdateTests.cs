﻿using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Update
{
    public class UpdateTests : Base.PaymentTests
    {
        public UpdateTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public void Update_PaymentOrder(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync( async () => {

                GoToPayexSwishPaymentFrame(products.Skip(1).ToArray())
                .Pay.Content.Should.BeEquivalent($"Betala {string.Format("{0:N2}", Convert.ToDecimal(products.Skip(1).First().UnitPrice / 100 * products.Skip(1).First().Quantity))} kr")
                .SwitchToRoot<HomePage>()
                .Header.Products.ClickAndGo();

                GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
                    .PaymentOrderLink.StoreValueAsUri(out var orderLink)
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].Should.BeVisible()
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCapture)].Should.BeVisible()
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
                    .Actions.Rows.Count.Should.Equal(3);

                await SwedbankPayClient.PaymentOrders.Get(orderLink, PaymentOrderExpand.All);
            });
        }
    }
}