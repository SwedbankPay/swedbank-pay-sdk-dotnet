using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentSaleTests : Base.PaymentTests
    {
        public PaymentSaleTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(2)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Payment_Swish_Sale(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .RefreshPageUntil(x => x.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].IsVisible, 30, 5)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible();

            var swishPayment = await SwedbankPayClient.Payments.SwishPayments.Get(_paymentLink, PaymentExpand.All);

            // Global Order
            Assert.That(swishPayment.Payment.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(swishPayment.Payment.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(swishPayment.Payment.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(swishPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);
            Assert.That(swishPayment.Operations[LinkRelation.ViewPayment], Is.Not.Null);

            // Transactions
            Assert.That(swishPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(swishPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                        Is.EqualTo(State.Completed));
        }

        //[Test]
        //[Retry(2)]
        //[TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Trustly })]
        //public async Task Payment_Trustly_Authorization(Product[] products, PayexInfo payexInfo)
        //{
        //    GoToOrdersPage(products, payexInfo, Checkout.Option.Standard)
        //        .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderReversal)].Should.BeVisible()
        //        .Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible();

        //    var trustlyPayment = await SwedbankPayClient.Payments.TrustlyPayments.Get(_paymentLink, PaymentExpand.All);

        //    // Global Order
        //    Assert.That(trustlyPayment.Payment.Amount.InLowestMonetaryUnit, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
        //    Assert.That(trustlyPayment.Payment.Currency.ToString(), Is.EqualTo("SEK"));
        //    Assert.That(trustlyPayment.Payment.State, Is.EqualTo(State.Ready));

        //    // Operations
        //    Assert.That(trustlyPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);
        //    Assert.That(trustlyPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
        //    Assert.That(trustlyPayment.Operations[LinkRelation.CreateCapture], Is.Null);
        //    Assert.That(trustlyPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

        //    // Transactions
        //    Assert.That(trustlyPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(1));
        //    Assert.That(trustlyPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
        //                Is.EqualTo(State.Completed));
        //}
    }
}
