using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Swish.OperationRequests;
using SwedbankPay.Sdk.Tests.TestBuilders;
using SwedbankPay.Sdk.Transactions;

using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class SwishPaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();



        [Fact]
        public async Task GetPayment()
        {
            var payment = await this.Sut.Payment.GetSwishPayment(new Uri("/psp/swish/payments/631afe5f-71db-45d9-f5f7-08d7942d8c7e", UriKind.Relative), PaymentExpand.All);
            Assert.NotNull(payment);
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
        public void A()
        {
            string content = "{\"payment\":\"/psp/swish/payments/638a76cd-3074-46a3-3863-08d7935a285d\",\"sale\":{\"date\":\"1/8/2020 10:09:48 AM +00:00\",\"paymentRequestToken\":\"02cc96518a6743da984aecf4eab908b1\",\"id\":\"/psp/swish/payments/638a76cd-3074-46a3-3863-08d7935a285d/sales/0f9be3dd-d5b8-4ec5-272f-08d7935a28f5\",\"transaction\":{\"id\":\"0f9be3dd-d5b8-4ec5-272f-08d7935a28f5\",\"created\":\"2020-01-08T10:08:29.8561754Z\",\"updated\":\"2020-01-08T10:09:48.7980445Z\",\"type\":\"Sale\",\"state\":\"AwaitingActivity\",\"number\":44100037133,\"amount\":160000,\"vatAmount\":0,\"description\":\"Test Description\",\"payeeReference\":\"637140785650600350\",\"isOperational\":true,\"operations\":[{\"method\":\"GET\",\"href\":\"swish://paymentrequest?token=02cc96518a6743da984aecf4eab908b1&callbackurl=https://example.com/payment-completed\",\"rel\":\"redirect-app-swish\"}]}}}";
            var transactionRequestContainer = JsonConvert.DeserializeObject<SwedbankPay.Sdk.Payments.Swish.SaleResponse>(content, JsonSerialization.JsonSerialization.Settings);

        }


        [Fact]
        public async Task AbortPayment()
        {
            var paymentRequest = this.paymentRequestBuilder.WithSwishTestValues().BuildSwishPaymentRequest();
            
            var payment = await this.Sut.Payment.CreateSwishPayment(paymentRequest);

            Assert.NotNull(payment);

            var paymentResponseContainer = await payment.Operations.Abort.Invoke();

            Assert.NotNull(paymentResponseContainer);
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
            var swishPayment = await this.Sut.Payment.CreateSwishPayment(paymentRequest);
            Assert.NotNull(swishPayment);
            Assert.NotNull(swishPayment.PaymentResponse);
        }


        //[Fact]
        //public async Task CreateCreditCardPayment_ShouldReturnPayment()
        //{
        //    var paymentRequest = this.paymentRequestBuilder.WithTestValues().BuildCreditardPaymentRequest();
        //    var swishPayment = await this.Sut.Payment.CreateCreditCardPayment(paymentRequest);
        //    Assert.NotNull(swishPayment);
        //    Assert.NotNull(swishPayment.PaymentResponse);
        //}
    }
}