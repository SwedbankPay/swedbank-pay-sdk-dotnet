using System;
using System.Linq;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.VippsPayments;
using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{

    public class VippsPaymentTests : ResourceTestsBase
    {

        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreatePayment()
        {
            var vippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(Operation.Purchase).BuildVippsRequest();
            var vippsPayment = await this.Sut.Payments.VippsPayments.Create(vippsPaymentRequest, PaymentExpand.All);

            Assert.NotNull(vippsPayment);
            Assert.Equal(vippsPaymentRequest.Payment.MetaData["key1"], vippsPayment.PaymentResponse.MetaData["key1"]);
            Assert.True(vippsPaymentRequest.Payment.Language.CultureTypes.Equals(vippsPayment.PaymentResponse.Language.CultureTypes));
            Assert.True(vippsPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
            Assert.NotNull(vippsPaymentRequest.Payment.UserAgent);
        }

        [Fact]
        public async Task CreateAndGetVippsPayment_ShouldReturnPaymentId()
        {
            var vippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(Operation.Purchase).BuildVippsRequest();
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
