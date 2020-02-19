using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentCaptureTests : Base.PaymentTests
    {
        public PaymentCaptureTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Capture(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Operations
            Assert.That(cardPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(cardPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                        Is.EqualTo(State.Completed));
        }

    }
}

