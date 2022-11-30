using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentVerificationTests : Base.PaymentTests
    {
        public PaymentVerificationTests(string driverAlias)
            : base(driverAlias)
        {
        }
        

        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Recurring })]
        public async Task Payment_Card_Verification(Product[] products, PayexInfo payexInfo)
        {
	        GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentlink"] == _referenceLink].IsVisible, 60, 10);

            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(new Uri(_referenceLink, UriKind.RelativeOrAbsolute), PaymentExpand.All);

            // Global Order
            Assert.That(cardPayment.Payment.Amount.InLowestMonetaryUnit, Is.EqualTo(0));
            Assert.That(cardPayment.Payment.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(cardPayment.Payment.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(cardPayment.Operations.Count, Is.EqualTo(2));
            Assert.That(cardPayment.Operations[LinkRelation.ViewPayment], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            Assert.That(cardPayment.Payment.RecurrenceToken, Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Verification).State,
                        Is.EqualTo(State.Completed));
        }

        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Recurring })]
        public async Task Payment_Card_Recurring(Product[] products, PayexInfo payexInfo)
        {
            var page = GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentlink"] == _referenceLink].IsVisible, 60, 10)
                .Orders[y => y.Attributes["data-paymentlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains("create-recurring")].ExecuteAction.ClickAndGo();
            
            var paymentUriLink1 = page.SuccessMessage.StorePaymentUri();

            await VerifyPayment(paymentUriLink1, products);


            page = page.Orders[y => y.Attributes["data-paymentlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains("create-recurring")].ExecuteAction.ClickAndGo();

            var paymentUriLink2 = page.SuccessMessage.StorePaymentUri();

            await VerifyPayment(paymentUriLink2, products);
        }

        private async Task VerifyPayment(string paymentLink, Product[] products)
        {
            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(new Uri(paymentLink, UriKind.RelativeOrAbsolute), PaymentExpand.All);

            // Global Order
            Assert.That(cardPayment.Payment.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(cardPayment.Payment.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(cardPayment.Payment.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(cardPayment.Operations.Count, Is.EqualTo(2));
            Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);
            Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(cardPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                        Is.EqualTo(State.Completed));
        }
    }
}