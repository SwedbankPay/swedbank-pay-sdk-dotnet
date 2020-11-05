using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class CardPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();


        [Fact]
        public async Task GetPayment()
        {
            var creditCardPayment = await this.Sut.Payments.CardPayments.Get(
                new Uri("/psp/creditcard/payments/23fb6fbd-3f09-4dcc-5d6e-08d7942d6bba", UriKind.Relative), PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }


        [Fact]
        public async Task CreateVerifyPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(this.payeeId, Operation.Verify).BuildCreditardPaymentRequest();
            var creditCardPayment = await this.Sut.Payments.CardPayments.Create(paymentRequest, PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }


        [Fact]
        public async Task CreatePayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(this.payeeId).BuildCreditardPaymentRequest();
            var creditCardPayment = await this.Sut.Payments.CardPayments.Create(paymentRequest, PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
            Assert.Equal(paymentRequest.Payment.Metadata["key1"], creditCardPayment.Payment.Metadata["key1"]);
        }
    }
}
