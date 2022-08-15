using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class TrustlyPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreatePayment()
        {
            var trustlyPaymentRequest = this.paymentRequestBuilder.WithTruslyTestValues(this.payeeId).BuildTrustlyRequest();
            var trustlyPayment = await this.Sut.Payments.TrustlyPayments.Create(trustlyPaymentRequest, PaymentExpand.All);

            Assert.NotNull(trustlyPayment);
            Assert.Equal(trustlyPaymentRequest.Payment.Intent, trustlyPayment.Payment.Intent);
            Assert.True(trustlyPayment.Payment.Language.ToString().Equals("sv-SE"));
            Assert.True(trustlyPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
            Assert.NotEmpty(trustlyPaymentRequest.Payment.UserAgent);
            Assert.Equal(trustlyPaymentRequest.Payment.Metadata["key1"], trustlyPayment.Payment.Metadata["key1"]);
            Assert.Equal(UserAgent.Default, trustlyPayment.Payment.InitiatingSystemUserAgent);
        }


        [Fact]
        public async Task AbortPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithTruslyTestValues(this.payeeId).BuildTrustlyRequest();

            var payment = await this.Sut.Payments.TrustlyPayments.Create(paymentRequest, PaymentExpand.All);

            Assert.NotNull(payment);
            Assert.NotNull(payment.Operations.Abort);

            var paymentResponseContainer = await payment.Operations.Abort(new PaymentAbortRequest());

            Assert.NotNull(paymentResponseContainer);
        }
    }
}
