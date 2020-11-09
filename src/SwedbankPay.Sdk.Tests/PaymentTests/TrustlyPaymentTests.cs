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
            var trustlyPaymentRequest = paymentRequestBuilder.WithTruslyTestValues(payeeId).BuildTrustlyRequest();
            var trustlyPayment = await Sut.Payments.TrustlyPayments.Create(trustlyPaymentRequest, PaymentExpand.All);

            Assert.NotNull(trustlyPayment);
            Assert.Equal(trustlyPaymentRequest.Payment.Intent, trustlyPayment.Payment.Intent);
            Assert.True(trustlyPayment.Payment.Language.Name.Equals("sv-SE"));
            Assert.True(trustlyPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
            Assert.NotEmpty(trustlyPaymentRequest.Payment.UserAgent);
        }


        [Fact]
        public async Task AbortPayment()
        {
            var paymentRequest = paymentRequestBuilder.WithTruslyTestValues(payeeId).BuildTrustlyRequest();

            var payment = await Sut.Payments.TrustlyPayments.Create(paymentRequest, PaymentExpand.All);

            Assert.NotNull(payment);
            Assert.NotNull(payment.Operations.Abort);

            var paymentResponseContainer = await payment.Operations.Abort(new PaymentAbortRequest());

            Assert.NotNull(paymentResponseContainer);
        }
    }
}
