using System.Linq;
using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    public class PaymentCancellationTests : Base.PaymentTests
    {
        public PaymentCancellationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public void Payment_Card_Cancellation(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync(async () =>
            {

                GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                    .PaymentLink.StoreValueAsUri(out var paymentLink)
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].ExecuteAction.ClickAndGo()
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                    .Actions.Rows.Count.Should.Equal(2);

                var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(paymentLink, PaymentExpand.All);

                // Operations
                Assert.That(cardPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
                Assert.That(cardPayment.Operations[LinkRelation.CreateCapture], Is.Null);
                Assert.That(cardPayment.Operations[LinkRelation.CreateReversal], Is.Null);
                Assert.That(cardPayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

                // Transactions
                Assert.That(cardPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
                Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                            Is.EqualTo(State.Completed));
                Assert.That(cardPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Cancellation).State,
                            Is.EqualTo(State.Completed));
            });
        }

        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Invoice })]
        public void Payment_Invoice_Cancellation(Product[] products, PayexInfo payexInfo)
        {
            Assert.DoesNotThrowAsync(async () => { 
                
                GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                    .PaymentLink.StoreValueAsUri(out var paymentLink)
                    .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].ExecuteAction.ClickAndGo();

                var invoicePayment = await SwedbankPayClient.Payments.InvoicePayments.Get(paymentLink, PaymentExpand.All);

                // Operations
                Assert.That(invoicePayment.Operations[LinkRelation.CreateCancellation], Is.Not.Null);
                Assert.That(invoicePayment.Operations[LinkRelation.CreateCapture], Is.Not.Null);
                Assert.That(invoicePayment.Operations[LinkRelation.CreateReversal], Is.Null);
                Assert.That(invoicePayment.Operations[LinkRelation.PaidPayment], Is.Not.Null);

                // Transactions
                Assert.That(invoicePayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
            });
        }
    }
}
