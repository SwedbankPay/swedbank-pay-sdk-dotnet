using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Card;
using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class CardPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();


        [Fact]
        public async Task GetPayment()
        {
            var creditCardPayment = await this.Sut.Payment.GetCreditCardPayment(
                new Uri("/psp/creditcard/payments/35a3ca24-745e-4ba1-5bbf-08d7942d6bba", UriKind.Relative), PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }




        [Fact]
        public async Task CreateVerifyPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(Operation.Verify).BuildCreditardPaymentRequest();
            var creditCardPayment = await this.Sut.Payment.CreateCreditCardPayment(paymentRequest, PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }


        [Fact]
        public async Task CreatePayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues().BuildCreditardPaymentRequest();
            var creditCardPayment = await this.Sut.Payment.CreateCreditCardPayment(paymentRequest, PaymentExpand.All);

            Assert.NotNull(creditCardPayment);
        }
    }
}
