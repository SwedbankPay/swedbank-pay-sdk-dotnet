using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.Tests
{
    public class PaymentOrderTests : ResourceTestsBase
    {
        private readonly PaymentOrderRequestBuilder paymentOrderRequestBuilder = new PaymentOrderRequestBuilder();


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
            Assert.NotNull(responseContainer.PaymentOrderResponse);
            Assert.Equal("Aborted", responseContainer.PaymentOrderResponse.State.Value);
        }


        [Fact]
        public async Task CreateAndGetPaymentOrder_ShouldReturnPaymentOrderWithSameAmount()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().Build();
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            var amount = paymentOrder.PaymentOrderResponse.Amount;

            var paymentOrder2 = await this.Sut.PaymentOrder.Get(paymentOrder.PaymentOrderResponse.Id);
            Assert.NotNull(paymentOrder2);
            Assert.NotNull(paymentOrder2.PaymentOrderResponse);
            Assert.Equal(amount.Value, paymentOrder2.PaymentOrderResponse.Amount.Value);
        }


        [Fact]
        public async Task CreateAndUpdateOnlyAmountOnPaymentOrder_ShouldThrowHttpResponseException()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().WithAmounts().Build();
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            var amount = paymentOrder.PaymentOrderResponse.Amount;

            var newAmount = 50000;
            var updateRequest = new PaymentOrderUpdateRequest
            {
                Amount = Amount.FromDecimal(newAmount)
            };

            await Assert.ThrowsAsync<HttpResponseException>(
                () => paymentOrder.Operations.Update?.Execute(new PaymentOrderUpdateRequestContainer(updateRequest)));
        }


        [Fact]
        public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrderWithNewAmounts()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().Build();

            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);

            var newAmount = 50000;
            var newVatAmount = 10000;
            var updateRequest = new PaymentOrderUpdateRequest
            {
                Amount = Amount.FromDecimal(newAmount),
                VatAmount = Amount.FromDecimal(newVatAmount)
            };
            Assert.NotNull(paymentOrder.Operations.Update);

            var response = await paymentOrder.Operations.Update?.Execute(new PaymentOrderUpdateRequestContainer(updateRequest));

            Assert.Equal(updateRequest.Amount.Value, response.PaymentOrderResponse.Amount.Value);
            Assert.Equal(updateRequest.VatAmount.Value, response.PaymentOrderResponse.VatAmount.Value);
        }

        [Fact]
        public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().Build();
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            Assert.Equal(paymentOrderRequest.Amount.Value, paymentOrder.PaymentOrderResponse.Amount.Value);
        }


        [Fact]
        public async Task CreatePaymentOrder_WithOrderItems_ShouldReturnOrderItemsIfExpanded()
        {
            //ARRANGE
            var paymentOrderRequestContainer =
                this.paymentOrderRequestBuilder.WithTestValues()
                    .WithOrderItems()
                    .Build();

            //ACT
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequestContainer, PaymentOrderExpand.OrderItems);

            //ASSERT
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            Assert.NotNull(paymentOrder.PaymentOrderResponse.OrderItems);
            Assert.NotEmpty(paymentOrder.PaymentOrderResponse.OrderItems.OrderItemList);
        }


        [Fact]
        public async Task GetPaymentOrder_WithPayment_ShouldReturnCurrentPaymentIfExpanded()
        {
            //ACT
            var paymentOrder = await this.Sut.PaymentOrder.Get(new Uri("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", UriKind.Relative),
                                                               PaymentOrderExpand.CurrentPayment);

            //ASSERT
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse.CurrentPayment);
            Assert.NotNull(paymentOrder.PaymentOrderResponse.CurrentPayment.Payment);
        }

        [Fact]
        public async Task GetPaymentOrder_WithSwishPayment_ShouldReturnSales()
        {
            //ACT
            var paymentOrder = await this.Sut.PaymentOrder.Get(new Uri("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", UriKind.Relative),
                                                               PaymentOrderExpand.CurrentPayment);
            //var sales = await this.Sut.Payment.GetSales(paymentOrder.PaymentOrderResponse.CurrentPayment.Payment.Sales.Id);

            //ASSERT
            //Assert.NotNull(sales);
            //Assert.NotEmpty(sales);
        }


        [Fact]
        public async Task GetUnknownPaymentOrder_ShouldThrowHttpResponseException()
        {
            var id = new Uri("/psp/paymentorders/56a45c8a-9605-437a-fb80-08d742822747", UriKind.Relative);

            await Assert.ThrowsAsync<HttpResponseException>(() => this.Sut.PaymentOrder.Get(id));
        }
    }
}