using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
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
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Capture(Product[] products, PayexInfo payexInfo)
        {
	        GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].ExecuteAction.ClickAndGo()
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
		        .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
		        .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible();

            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(_paymentLink, PaymentExpand.All);

            // Operations
            Assert.That(cardPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                        Is.EqualTo(State.Completed));
        }

    }
}

