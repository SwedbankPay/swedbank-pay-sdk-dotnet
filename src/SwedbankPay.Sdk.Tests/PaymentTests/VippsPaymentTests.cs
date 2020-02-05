using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Vipps;
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
            var VippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(Operation.Purchase).BuildVippsRequest();
            var VippsPayment = await this.Sut.Payment.CreateVippsPayment(VippsPaymentRequest, PaymentExpand.All);

            Assert.NotNull(VippsPayment);
            Assert.Equal(VippsPaymentRequest.Payment.MetaData["key1"], VippsPayment.PaymentResponse.MetaData["key1"]);
            Assert.True(VippsPaymentRequest.Payment.Language.CultureTypes.Equals("nb-NO"));
            Assert.True(VippsPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
            Assert.NotNull(VippsPaymentRequest.Payment.UserAgent);

            //Sjekk om Payment
        }

    }


    
}
