using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;
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
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Payment_Swish_Sale(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreUri(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(3);

            var swishPayment = await SwedbankPayClient.Payments.SwishPayments.Get(paymentLink, PaymentExpand.All);

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

        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Trustly })]
        public async Task Payment_Trustly_Sale(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreUri(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(2);

            var trustlyPayment = await SwedbankPayClient.Payments.TrustlyPayments.Get(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Global Order
            Assert.That(trustlyPayment.PaymentResponse.Amount.Value, Is.EqualTo(products.Select(x => x.UnitPrice * x.Quantity).Sum()));
            Assert.That(trustlyPayment.PaymentResponse.Currency.ToString(), Is.EqualTo("SEK"));
            Assert.That(trustlyPayment.PaymentResponse.State, Is.EqualTo(State.Ready));

            // Operations
            Assert.That(trustlyPayment.Operations.Count, Is.EqualTo(2));
            Assert.That(trustlyPayment.Operations[LinkRelation.CreateReversal], Is.Not.Null);
            Assert.That(trustlyPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(trustlyPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(1));
            Assert.That(trustlyPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                        Is.EqualTo(State.Completed));
        }
    }
}
