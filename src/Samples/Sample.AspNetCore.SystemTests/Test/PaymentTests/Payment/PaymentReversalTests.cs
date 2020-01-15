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
    public class PaymentReversalTests : Base.PaymentTests
    {
        public PaymentReversalTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public async Task Payment_Card_Reversal(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var order = await SwedbankPayClient.Payment.GetCreditCardPayment(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(3));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionTypes.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionTypes.Capture).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionTypes.Reversal).State,
                        Is.EqualTo(State.Completed));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Payment_Swish_Reversal(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var swishPayment = await SwedbankPayClient.Payment.GetSwishPayment(paymentLink, SwedbankPay.Sdk.Payments.PaymentExpand.All);

            // Operations
            Assert.That(swishPayment.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);

            // Transactions
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == Intent.Sale.ToString()).State,
                        Is.EqualTo(State.Completed));
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionTypes.Reversal).State,
                        Is.EqualTo(State.Completed));
        }

    }
}
