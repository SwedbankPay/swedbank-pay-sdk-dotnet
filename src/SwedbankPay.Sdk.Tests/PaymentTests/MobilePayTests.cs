using System.Threading.Tasks;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using Xunit;


namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class MobilePayTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact(Skip ="Not supported by merchants that have both Checkout and Payment Pages")]
        public async Task CreateMobilePayPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithMobilePayTestValues(this.payeeId).BuildMobilePayRequest();
            var mobilePayPayment = await this.Sut.Payments.MobilePayPayments.Create(paymentRequest, PaymentExpand.All);
            Assert.NotNull(mobilePayPayment);
        }
    }
}
