using System.Linq;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentCancellationTests : Base.PaymentTests
    {
        public PaymentCancellationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Cancellation(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = await SwedbankPayClient.Payment.GetCreditCardPayment(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Authorization").State.Value,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == "Cancellation").State.Value,
                        Is.EqualTo(State.Completed));
        }

    }
}
