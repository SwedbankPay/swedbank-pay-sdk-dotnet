using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Card;
using SwedbankPay.Sdk.Tests.TestBuilders;
using SwedbankPay.Sdk.Transactions;

using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class CardPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();


        [Fact]
        public async Task GetPayment()
        {
            var creditCardPayment = await this.Sut.Payment.GetCreditCardPayment(
                new Uri("/psp/creditcard/payments/16a4cb4f-8d6e-4376-5bf7-08d7942d6bba", UriKind.Relative), PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }


        //[Fact]
        //public async Task CapturePayment()
        //{
        //    var creditCardPayment = await this.Sut.Payment.GetCreditCardPayment(new Uri("/psp/creditcard/payments/16a4cb4f-8d6e-4376-5bf7-08d7942d6bba", UriKind.Relative), PaymentExpand.All);
        //    creditCardPayment.Operations.Capture.Execute(new TransactionRequestContainer<TransactionRequest>(
        //                                                     new TransactionRequest(Amount.FromDecimal(1600), "description", null,
        //                                                                            DateTime.Now.Ticks.ToString(), Amount.FromDecimal(0))));

        //    Assert.NotNull(creditCardPayment);
        //}

        [Fact]
        public async Task CreateVerifyPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(Operation.Verify).BuildCreditardPaymentRequest();
            var creditCardPayment = await this.Sut.Payment.CreateCreditCardPayment(paymentRequest, PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }


        [Fact]
        public async Task CreatePayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues().BuildCreditardPaymentRequest();
            var creditCardPayment = await this.Sut.Payment.CreateCreditCardPayment(paymentRequest, PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }
    }
}
