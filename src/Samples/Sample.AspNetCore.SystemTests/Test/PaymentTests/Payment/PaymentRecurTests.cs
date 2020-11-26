using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentRecurTests : Base.PaymentTests
    {
        public PaymentRecurTests(string driverAlias) : base(driverAlias)
        {
        }

        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Recur(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(4);

            var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(paymentLink, PaymentExpand.All);

            Assert.NotNull(cardPayment.Payment.RecurrenceToken);
            Assert.True(!string.IsNullOrEmpty(cardPayment.Payment.RecurrenceToken));
        }
    }
}
