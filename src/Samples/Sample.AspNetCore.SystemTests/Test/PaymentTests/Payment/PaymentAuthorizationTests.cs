using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentAuthorizationTests : Base.PaymentTests
    {
        public PaymentAuthorizationTests(string driverAlias)
            : base(driverAlias)
        {
        }
        

        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Authorization(Product[] products, PayexInfo payexInfo)
        {
	        GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].IsVisible, 30, 5)
		        .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].Should.BeVisible()
		        .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].Should.BeVisible()
		        .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
		        .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible();

            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(_paymentLink, PaymentExpand.All);

            // Global Order
            Assert.That(cardPayment.Payment.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(cardPayment.Payment.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(cardPayment.Payment.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCancellation], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.CreateCapture], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
        }
    }
}