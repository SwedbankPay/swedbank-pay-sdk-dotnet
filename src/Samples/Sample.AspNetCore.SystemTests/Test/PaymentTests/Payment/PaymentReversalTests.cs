using System.Linq;
using System.Threading;
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

            var order = await SwedbankPayClient.Payments.GetCreditCardPayment(paymentLink, PaymentExpand.All);

            // Operations
            Assert.That(order.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(order.Operations[LinkRelation.CreateReversal], Is.Null);
            Assert.That(order.Operations[LinkRelation.PaidPayment], Is.Not.Null);

            // Transactions
            Assert.That(order.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(3));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Capture).State,
                        Is.EqualTo(State.Completed));
            Assert.That(order.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State,
                        Is.EqualTo(State.Completed));
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Swish })]
        public async Task Payment_Swish_Reversal(Product[] products, PayexInfo payexInfo)
        {
            GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
                .PaymentLink.StoreValue(out var paymentLink)
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateReversal)].ExecuteAction.ClickAndGo()
                .Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible()
                .Actions.Rows.Count.Should.Equal(1);

            var swishPayment = await SwedbankPayClient.Payments.GetSwishPayment(paymentLink, PaymentExpand.All);
            var counter = 0;

            while (swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State != State.Completed && counter <= 15)
            {
                Thread.Sleep(1000);
                swishPayment = await SwedbankPayClient.Payments.GetSwishPayment(paymentLink, PaymentExpand.All);
                counter++;
            }

            // Operations
            Assert.That(swishPayment.Operations[LinkRelation.CreateCancellation], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateCapture], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.CreateReversal], Is.Null);
            Assert.That(swishPayment.Operations[LinkRelation.ViewPayment], Is.Not.Null);

            // Transactions
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.Count, Is.EqualTo(2));
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Sale).State,
                        Is.EqualTo(State.Completed));
            Assert.That(swishPayment.PaymentResponse.Transactions.TransactionList.First(x => x.Type == TransactionType.Reversal).State,
                        Is.EqualTo(State.Completed));
        }

    }
}
