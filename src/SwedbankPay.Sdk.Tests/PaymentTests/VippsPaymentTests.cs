using System.Linq;
using System.Threading.Tasks;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{

    public class VippsPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreateVippsPayment_ShouldReturnWithExpectedValues()
        {
            var vippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(this.payeeId ,Operation.Purchase).BuildVippsRequest();
            var vippsPayment = await this.Sut.Payments.VippsPayments.Create(vippsPaymentRequest, PaymentExpand.All);

            Assert.NotNull(vippsPayment);
            Assert.Equal(vippsPaymentRequest.Payment.Metadata["key1"], vippsPayment.PaymentResponse.Metadata["key1"]);
            Assert.True(vippsPaymentRequest.Payment.Language.CultureTypes.Equals(vippsPayment.PaymentResponse.Language.CultureTypes));
            Assert.True(vippsPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
            Assert.True(vippsPaymentRequest.Payment.Currency.ToString().Equals(vippsPayment.PaymentResponse.Currency.ToString()));
            Assert.True(vippsPaymentRequest.Payment.Description.Length.Equals(vippsPayment.PaymentResponse.Description.Length));
            Assert.True(vippsPaymentRequest.Payment.UserAgent.Length.Equals(vippsPayment.PaymentResponse.UserAgent.Length));
            Assert.True(vippsPaymentRequest.Payment.PayeeInfo.PayeeId.Equals(vippsPayment.PaymentResponse.PayeeInfo.PayeeId));
            Assert.NotNull(vippsPaymentRequest.Payment.UserAgent);
        }

        [Fact]
        public async Task CreateAndGetVippsPayment_ShouldReturnPaymentId()
        {
            var vippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(this.payeeId, Operation.Purchase).BuildVippsRequest();
            var vippsPayment = await this.Sut.Payments.VippsPayments.Create(vippsPaymentRequest, PaymentExpand.All);
            var vippsPaymentId = vippsPayment.PaymentResponse.Id;
            var getVippsPayment = await this.Sut.Payments.VippsPayments.Get(vippsPaymentId);

            Assert.NotNull(getVippsPayment);

            var priceList = vippsPayment.PaymentResponse.Prices.PriceList;

            Assert.NotEmpty(priceList);
            var price = priceList.First();

            Assert.Equal(vippsPaymentRequest.Payment.Prices.First().Amount.Value, price.Amount.Value);
        }
    } 
}
