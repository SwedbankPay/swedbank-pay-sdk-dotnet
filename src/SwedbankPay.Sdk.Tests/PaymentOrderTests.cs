namespace SwedbankPay.Sdk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Tests.TestBuilders;
    using SwedbankPay.Sdk.Exceptions;

    using Xunit;

    public class PaymentOrderTests : ResourceTestsBase
    {
        private readonly PaymentOrderRequestBuilder paymentOrderRequestBuilder = new PaymentOrderRequestBuilder();

        [Fact]
        public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
        {
            var paymentOrderRequest = this.paymentOrderRequestBuilder.WithTestValues().Build();
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            Assert.Equal(paymentOrderRequest.Amount.Value, paymentOrder.PaymentOrderResponse.Amount.Value);
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

        [Fact]
        public async Task CreatePaymentOrder_ShouldReturnMetaData()
        {
            var orderRequestContainer = CreatePaymentOrderRequest();
            orderRequestContainer.MetaData = new Dictionary<string, object>
            {
                ["testvalue"] = 3,
                ["testvalue2"] = "test"
            };

            var paymentOrder = await this.Sut.PaymentOrder.Create(orderRequestContainer, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            Assert.NotNull(paymentOrder.PaymentOrderResponse.MetaData);
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
        public async Task GetPaymentOrder_WithSwishPayment_ShouldReturnSales()
        {
            //ACT
            var paymentOrder = await this.Sut.PaymentOrder.Get("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", PaymentOrderExpand.CurrentPayment);
            var sales = await this.Sut.Payment.GetSales(paymentOrder.PaymentOrderResponse.CurrentPayment.Payment.Sales.Id);

            //ASSERT
            Assert.NotNull(sales);
            Assert.NotEmpty(sales);
        }

        [Fact]
        public async Task CreateAndGetPaymentOrder_ShouldReturnPaymentOrderWithSameAmount()
        {
            var paymentOrderRequest = CreatePaymentOrderRequest();
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
        public async Task CreateAndUpdateOnlyAmountOnPaymentOrder_ShouldThrowCouldNotUpdatePaymentOrderException()
        {
            var paymentOrderRequest = CreatePaymentOrderRequest(30000, 7500);
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);
            var amount = paymentOrder.PaymentOrderResponse.Amount;

            var newAmount = 50000;
            var updateRequest = new PaymentOrderUpdateRequest
            {
                Amount = Amount.FromDecimal(newAmount),
            };

            await Assert.ThrowsAsync<CouldNotUpdatePaymentOrderException>(() => paymentOrder.Operations.Update?.Execute(new PaymentOrderUpdateRequestContainer(updateRequest)));
        }

        [Fact]
        public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrderWithNewAmounts()
        {
            var paymentOrderRequest = CreatePaymentOrderRequest();
            var paymentOrder = await this.Sut.PaymentOrder.Create(paymentOrderRequest, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrder);
            Assert.NotNull(paymentOrder.PaymentOrderResponse);

            var newAmount = 50000;
            var newVatAmount = 10000;
            var updateRequest = new PaymentOrderUpdateRequest()
            {
                Amount = Amount.FromDecimal(newAmount),
                VatAmount = Amount.FromDecimal(newVatAmount)
            };
            Assert.NotNull(paymentOrder.Operations.Update);

            var response = await paymentOrder.Operations.Update?.Execute(new PaymentOrderUpdateRequestContainer(updateRequest));


            Assert.Equal(updateRequest.Amount.Value, response.PaymentOrder.Amount.Value);
            Assert.Equal(updateRequest.VatAmount.Value, response.PaymentOrder.VatAmount.Value);
        }

        [Fact]
        public async Task GetUnknownPaymentOrder_ShouldThrowCouldNotFindPaymentException()
        {
            var id = "/psp/paymentorders/56a45c8a-9605-437a-fb80-08d742822747";

            await Assert.ThrowsAsync<CouldNotFindPaymentException>(() => this.Sut.PaymentOrder.Get(id));
        }

        private PaymentOrderRequest CreatePaymentOrderRequest(long amount = 30000, long vatAmount = 7500)
        {
            return new PaymentOrderRequest
            {
                Amount = Amount.FromDecimal(amount),
                VatAmount = Amount.FromDecimal(vatAmount),
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