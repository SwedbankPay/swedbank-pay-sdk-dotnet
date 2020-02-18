using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using Xunit;


namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class MobilePayTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreateMobilePayPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithMobilePayTestValues().BuildMobilePayRequest();
            var mobilePayPayment = await this.Sut.Payments.MobilePayPayments.Create(paymentRequest, PaymentExpand.All);
            Assert.NotNull(mobilePayPayment);
        }

        [Fact]
        public async Task GetPayment()
        {
            var payment = await this.Sut.Payments.MobilePayPayments.Get(
                new Uri("", UriKind.Relative), PaymentExpand.All);
            Assert.NotNull(payment);
        }

    }
}
