using System.Linq;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;

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

            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(paymentLink, PaymentExpand.All);

            // Operations
            Assert.That(cardPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Cancellation).State,
                        Is.EqualTo(State.Completed));
        }

    }
}
