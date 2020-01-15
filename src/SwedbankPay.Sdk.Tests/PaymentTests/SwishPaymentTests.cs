using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Swish;
using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class SwishPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();


        [Fact]
        public async Task AbortPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues().BuildSwishPaymentRequest();

            var payment = await this.Sut.Payment.CreateSwishPayment(paymentRequest);

            Assert.NotNull(payment);

            var paymentResponseContainer = await payment.Operations.Abort.Invoke();

            Assert.NotNull(paymentResponseContainer);
        }


        [Fact]
        public async Task CreateMCommerceSale()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues().BuildSwishPaymentRequest();
            var payment = await this.Sut.Payment.CreateSwishPayment(paymentRequest);

            Assert.NotNull(payment);

            var saleResponseContainer = await payment.Operations.CreateSale?.Invoke(new SaleRequest(null));

            Assert.NotNull(saleResponseContainer);
            Assert.NotNull(saleResponseContainer.Sale);
        }


        [Fact]
        public async Task CreateSale()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues().BuildSwishPaymentRequest();
            var payment = await this.Sut.Payment.CreateSwishPayment(paymentRequest);

            Assert.NotNull(payment);

            var saleResponseContainer = await payment.Operations.CreateSale?.Invoke(new SaleRequest(new Msisdn("+46701234567")));

            Assert.NotNull(saleResponseContainer);
            Assert.NotNull(saleResponseContainer.Sale);
        }


        //[Fact]
        //public async Task CreateReversal()
        //{
        //    var paymentRequest = this.paymentRequestBuilder.WithTestValues().BuildSwishPaymentRequest();
        //    var payment = await this.Sut.Payment.CreateSwishPayment(paymentRequest);

        //    Assert.NotNull(payment);

        //    var saleResponseContainer = await payment.Operations.CreateSale?.Execute(
        //        new TransactionRequestContainer<SaleTransactionRequest>(new Payments.Swish.Transactions.SaleTransactionRequest(new Msisdn("+46701234567"))));

        //    Assert.NotNull(saleResponseContainer);
        //    Assert.NotNull(saleResponseContainer.Sale);

        //    await Task.Delay(3000);
        //    var swishPayment = await this.Sut.Payment.GetSwishPayment(saleResponseContainer.Payment);
        //    var responseContainer = await swishPayment.Operations.CreateReversal?.Execute(new TransactionRequestContainer<ReversalTransactionRequest>(
        //                                                                                      new Payments.Swish.Transactions.ReversalTransactionRequest(
        //                                                                                          Amount.FromDecimal(1700), Amount.FromDecimal(0), "Description",
        //                                                                                          DateTime.Now.Ticks.ToString())));
        //    Assert.NotNull(responseContainer);
        //}


        [Fact]
        public async Task CreateSwishPayment_ShouldReturnPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues().BuildSwishPaymentRequest();
            var swishPayment = await this.Sut.Payment.CreateSwishPayment(paymentRequest, PaymentExpand.All);
            Assert.NotNull(swishPayment);
            Assert.NotNull(swishPayment.PaymentResponse);
            Assert.Equal(paymentRequest.Payment.MetaData["key1"], swishPayment.PaymentResponse.MetaData["key1"]);
        }


        [Fact]
        public async Task GetPayment()
        {
            var payment = await this.Sut.Payment.GetSwishPayment(
                new Uri("/psp/swish/payments/dda2cbde-117a-4742-cbc9-08d7942e23d8", UriKind.Relative), PaymentExpand.All);
            Assert.NotNull(payment);
        }
    }
}