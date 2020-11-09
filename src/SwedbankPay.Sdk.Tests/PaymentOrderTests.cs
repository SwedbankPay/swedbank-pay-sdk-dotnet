using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Net;
using System.Threading.Tasks;
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

            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues(this.payeeId).Build();

            //ACT
            var paymentOrder = await this.Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotEmpty(paymentOrder.Operations);
            Assert.NotNull(paymentOrder.Operations.Abort);

            var responseContainer = await paymentOrder.Operations.Abort();

            Assert.NotNull(responseContainer);
            Assert.NotNull(responseContainer.PaymentOrder);
            Assert.Equal(State.Aborted, responseContainer.PaymentOrder.State);
        }



        [Fact]
        public async Task CreateAndGetPaymentOrder_ShouldReturnPaymentOrderWithSameAmountAndMetadata()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues(this.payeeId).Build();
            var paymentOrder = await this.Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrder);
            var amount = paymentOrder.PaymentOrder.Amount;

            var paymentOrder2 = await this.Sut.PaymentOrders.Get(paymentOrder.PaymentOrder.Id, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder2);
            Assert.NotNull(paymentOrder2.PaymentOrder);
            Assert.Equal(amount.InLowestMonetaryUnit, paymentOrder2.PaymentOrder.Amount.InLowestMonetaryUnit);

            Assert.Equal(paymentOrderRequest.PaymentOrder.Metadata["key1"], paymentOrder2.PaymentOrder.Metadata["key1"]);
        }


        [Fact]
        public async Task CreateAndUpdateOnlyAmountOnPaymentOrder_ShouldThrowHttpResponseException()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues(this.payeeId).WithAmounts().Build();
            var paymentOrder = await this.Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrder);

            var newAmount = 50000;
            var updateRequest = new PaymentOrderUpdateRequest(new Amount(newAmount), null);

            await Assert.ThrowsAsync<HttpResponseException>(() => paymentOrder.Operations.Update?.Invoke(updateRequest));
        }


        [Fact]
        public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrderWithNewAmounts()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues(this.payeeId).Build();

            var paymentOrder = await this.Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrder);

            var newAmount = 50000;
            var newVatAmount = 10000;
            var updateRequest = new PaymentOrderUpdateRequest(new Amount(newAmount), new Amount(newVatAmount));
            Assert.NotNull(paymentOrder.Operations.Update);

            var response = await paymentOrder.Operations.Update(updateRequest);

            Assert.Equal(updateRequest.PaymentOrder.Amount.InLowestMonetaryUnit, response.PaymentOrder.Amount.InLowestMonetaryUnit);
            Assert.Equal(updateRequest.PaymentOrder.VatAmount.InLowestMonetaryUnit, response.PaymentOrder.VatAmount.InLowestMonetaryUnit);
        }

        [Fact]
        public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues(this.payeeId).Build();
            var paymentOrder = await this.Sut.PaymentOrders.Create(paymentOrderRequest);
            Assert.NotNull(paymentOrder.PaymentOrder);
            Assert.Equal(paymentOrderRequest.PaymentOrder.Amount.InLowestMonetaryUnit, paymentOrder.PaymentOrder.Amount.InLowestMonetaryUnit);
        }


        [Fact]
        public async Task CreatePaymentOrder_WithOrderItems_ShouldReturnOrderItemsIfExpanded()
        {
            //ARRANGE
            var paymentOrderRequestContainer =
                this.paymentOrderRequestBuilder.WithTestValues(this.payeeId)
                    .WithOrderItems()
                    .Build();

            //ACT
            var paymentOrder = await this.Sut.PaymentOrders.Create(paymentOrderRequestContainer, PaymentOrderExpand.OrderItems);

            //ASSERT
            Assert.NotNull(paymentOrder.PaymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrder.OrderItems);
            Assert.NotEmpty(paymentOrder.PaymentOrder.OrderItems.OrderItemList);
        }


        [Fact]
        public async Task GetPaymentOrder_WithPayment_ShouldReturnCurrentPaymentIfExpanded()
        {
            //ARRANGE
            _ =
                this.paymentOrderRequestBuilder.WithTestValues(this.payeeId)
                    .WithOrderItems()
                    .Build();

            //ACT
            var paymentOrder = await this.Sut.PaymentOrders.Get(new Uri("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", UriKind.Relative),
                                                               PaymentOrderExpand.CurrentPayment);

            //ASSERT
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrder.CurrentPayment);
            Assert.NotNull(paymentOrder.PaymentOrder.CurrentPayment.Payment);
        }

        [Fact]
        public async Task GetUnknownPaymentOrder_ShouldThrowHttpResponseException()
        {
            var id = new Uri("/psp/paymentorders/56a45c8a-9605-437a-fb80-08d742822747", UriKind.Relative);

            var thrownException = await Assert.ThrowsAsync<HttpResponseException>(() => this.Sut.PaymentOrders.Get(id));
            Assert.Equal(HttpStatusCode.NotFound, thrownException.HttpResponse.StatusCode);
        }
    }
}