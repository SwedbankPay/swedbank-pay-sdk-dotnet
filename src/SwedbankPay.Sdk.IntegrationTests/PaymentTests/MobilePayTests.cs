using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System.Threading.Tasks;
using Xunit;


namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class MobilePayTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreateMobilePayPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithMobilePayTestValues(this.payeeId).BuildMobilePayRequest();
            var mobilePayPayment = await this.SutMobilePay.Payments.MobilePayPayments.Create(paymentRequest, PaymentExpand.All);
            Assert.NotNull(mobilePayPayment);
        }
    }
}
