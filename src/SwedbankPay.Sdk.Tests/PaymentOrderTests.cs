namespace SwedbankPay.Sdk.Tests
{
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Tests.TestBuilders;
    using SwedbankPay.Sdk.Transactions;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SwedbankPay.Sdk.Payments;

    using Xunit;

    public class PaymentOrderTests : ResourceTestsBase
    {
        private readonly PaymentOrderRequestBuilder paymentOrderRequestBuilder = new PaymentOrderRequestBuilder();

        [Fact]
        public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().Build();
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest);
            //PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            Assert.Equal(paymentOrderRequest.Amount, paymentOrder.PaymentOrderResponse.Amount);
        }

        [Fact]
        public async Task GetPaymentOrder_WithPayment_ShouldReturnCurrentPaymentIfExpanded()
        {
            //ACT
            var paymentOrder = await this.Sut.PaymentOrder.Get("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", PaymentOrderExpand.CurrentPayment);

            //ASSERT
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse.CurrentPayment);
            Assert.NotNull(paymentOrder.PaymentOrderResponse.CurrentPayment.Payment);
        }

        [Fact]
        public async Task CreateAndAbortPaymentOrder_ShouldReturnAbortedState()
        {
            //ARRANGE
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().Build();

            //ACT
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotEmpty(paymentOrder.Operations);
            Assert.NotNull(paymentOrder.Operations.Abort);

            var responseContainer = await paymentOrder.Operations.Abort.Execute();

            Assert.NotNull(responseContainer);
            Assert.NotNull(responseContainer.PaymentOrder);
            Assert.Equal("Aborted", responseContainer.PaymentOrder.State.Value);
        }

        
        private PaymentOrderRequest CreatePaymentOrderRequest(long amount = 30000, long vatAmount = 7500)
        {
            return new PaymentOrderRequest
            {
                Amount = amount,
                VatAmount = vatAmount,
                Currency = new CurrencyCode("SEK"),
                Description = "Description",
                Language = new Language("sv-SE"),
                UserAgent = "useragent",
                PayeeInfo = new PayeeInfo
                {
                    PayeeId = "91a4c8e0-72ac-425c-a687-856706f9e9a1",
                    PayeeReference = DateTime.Now.Ticks.ToString(),
                }
            };
        }


    }
}