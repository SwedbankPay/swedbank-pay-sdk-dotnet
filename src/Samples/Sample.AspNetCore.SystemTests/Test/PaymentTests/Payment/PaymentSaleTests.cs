using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentOrders;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentSaleTests : Base.PaymentTests
    {
        public PaymentSaleTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Payment_Swish_Sale(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var swishPayment = await SwedbankPayClient.Payment.GetSwishPayment(paymentLink, PaymentExpand.All);

            // Global Order
            Assert.That(swishPayment.PaymentResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(swishPayment.PaymentResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(swishPayment.PaymentResponse.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(swishPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);
            Assert.That(swishPayment.Operations[LinkRelation.ViewPayment], Is.Not.Null);

            // Transactions
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                        Is.EqualTo(State.Completed));
        }

    }
}
