using System;
using System.Linq;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Tests.TestBuilders;

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
            Assert.Equal(trustlyPaymentRequest.Payment.Intent, trustlyPayment.PaymentResponse.Intent);
            Assert.True(trustlyPayment.PaymentResponse.Language.Name.Equals("sv-SE"));
            Assert.True(trustlyPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
            Assert.NotEmpty(trustlyPaymentRequest.Payment.UserAgent);
        }
    }
}
