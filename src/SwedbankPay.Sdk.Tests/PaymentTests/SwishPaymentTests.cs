using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class SwishPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task AbortPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues(this.payeeId).BuildSwishPaymentRequest();

            var payment = await this.Sut.Payments.SwishPayments.Create(paymentRequest);

            Assert.NotNull(payment);
            Assert.NotNull(payment.Operations.Abort);

            var paymentResponseContainer = await payment.Operations.Abort(new PaymentAbortRequest());

            Assert.NotNull(paymentResponseContainer);
        }


        [Fact]
        public async Task CreateMCommerceSale()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues(this.payeeId).BuildSwishPaymentRequest();
            var payment = await this.Sut.Payments.SwishPayments.Create(paymentRequest);

            Assert.NotNull(payment);

            var saleResponseContainer = await payment.Operations.Sale?.Invoke(new SwishPaymentSaleRequest(null));

            Assert.NotNull(saleResponseContainer);
            Assert.NotNull(saleResponseContainer.Sale);
        }


        [Fact]
        public async Task CreateSale()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues(this.payeeId).BuildSwishPaymentRequest();
            var payment = await this.Sut.Payments.SwishPayments.Create(paymentRequest);

            Assert.NotNull(payment);

            var saleResponseContainer = await payment.Operations.Sale?.Invoke(new SwishPaymentSaleRequest(new Msisdn("+46701234567")));

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
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues(this.payeeId).BuildSwishPaymentRequest();
            var swishPayment = await this.Sut.Payments.SwishPayments.Create(paymentRequest, PaymentExpand.All);
            Assert.NotNull(swishPayment);
            Assert.NotNull(swishPayment.Payment);
            Assert.Equal(paymentRequest.Payment.Metadata["key1"], swishPayment.Payment.Metadata["key1"]);
        }


        [Fact]
        public async Task GetPayment()
        {
            var payment = await this.Sut.Payments.SwishPayments.Get(
                new Uri("/psp/swish/payments/dda2cbde-117a-4742-cbc9-08d7942e23d8", UriKind.Relative), PaymentExpand.All);
            Assert.NotNull(payment);
        }
    }
}