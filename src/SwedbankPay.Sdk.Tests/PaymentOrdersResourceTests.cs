using System.Linq;

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

    public class PaymentOrdersResourceTests : ResourceTestsBase
    {
        private readonly PaymentOrderRequestBuilder paymentOrderRequestBuilder = new PaymentOrderRequestBuilder();

        //[Fact]
        //public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest();
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
        //    Assert.Equal(30000, paymentOrderResponseContainer.PaymentOrder.Amount);
        //}

        //[Fact]
        //public async Task CreatePaymentOrder_ShouldReturnMetaData()
        //{
        //    var orderRequestContainer = CreatePaymentOrderRequest();
        //    orderRequestContainer.MetaData = new Dictionary<string, object>
        //    {
        //        ["testvalue"] = 3,
        //        ["testvalue2"] = "test"
        //    };

        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(orderRequestContainer, PaymentOrderExpand.All);
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
        //}

        //[Fact]
        //public async Task CreatePaymentOrder_WithOrderItems_ShouldReturnOrderItemsIfExpanded()
        //{

        //    //ARRANGE
        //    var paymentOrderRequestContainer =
        //        this.paymentOrderRequestBuilder.WithTestValues()
        //            .WithOrderItems()
        //            .Build();

        //    //ACT
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.OrderItems);

        //    //ASSERT
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
        //    Assert.NotEmpty(paymentOrderResponseContainer.PaymentOrder.OrderItems.OrderItemList);

        //}

        //[Fact]
        //public async Task GetPaymentOrder_WithPayment_ShouldReturnCurrentPaymentIfExpanded()
        //{
        //    //ACT
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.GetPaymentOrder("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", PaymentOrderExpand.CurrentPayment);

        //    //ASSERT
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder.CurrentPayment);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder.CurrentPayment.Payment);
        //}

        //[Fact]
        //public async Task GetPaymentOrder_WithSwishPayment_ShouldReturnSales()
        //{
        //    //ACT
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.GetPaymentOrder("/psp/paymentorders/472e6f26-a9b5-4e91-1b70-08d756b9b7d8", PaymentOrderExpand.CurrentPayment);
        //    var sales = await this.Sut.Payment.GetSales(paymentOrderResponseContainer.PaymentOrder.CurrentPayment.Payment.Sales.Id);

        //    //ASSERT
        //    Assert.NotNull(sales);
        //    Assert.NotEmpty(sales);
        //}

        //[Fact]
        //public async Task CreateAndGetPaymentOrder_ShouldReturnPaymentOrderWithSameAmount()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest();
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
        //    var amount = paymentOrderResponseContainer.PaymentOrder.Amount;

        //    var paymentOrderResponseContainer2 = await this.Sut.PaymentOrders.GetPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id);
        //    Assert.NotNull(paymentOrderResponseContainer2);
        //    Assert.NotNull(paymentOrderResponseContainer2.PaymentOrder);
        //    Assert.Equal(amount, paymentOrderResponseContainer2.PaymentOrder.Amount);
        //}


        //[Fact]
        //public async Task CreateAndUpdateOnlyAmountOnPaymentOrder_ShouldThrowCouldNotUpdatePaymentOrderException()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest(30000, 7500);
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
        //    var amount = paymentOrderResponseContainer.PaymentOrder.Amount;

        //    var newAmount = 50000;
        //    var orderRequestContainer = new PaymentOrderRequest
        //    {
        //        Amount = newAmount,
        //    };

        //    await Assert.ThrowsAsync<CouldNotUpdatePaymentOrderException>(() => this.Sut.PaymentOrders.UpdatePaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, orderRequestContainer));
        //}


        //[Fact]
        //public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrderWithNewAmounts()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest();
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);
        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

        //    var newAmount = 50000;
        //    var newVatAmount = 10000;
        //    var orderRequest = new PaymentOrderRequest
        //    {
        //        Amount = newAmount,
        //        VatAmount = newVatAmount
        //    };

        //    var paymentOrderResponseContainer2 = await this.Sut.PaymentOrders.UpdatePaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, orderRequest);
        //    Assert.NotNull(paymentOrderResponseContainer2);
        //    Assert.NotNull(paymentOrderResponseContainer2.PaymentOrder);
        //    Assert.Equal(newAmount, paymentOrderResponseContainer2.PaymentOrder.Amount);
        //    Assert.Equal(newVatAmount, paymentOrderResponseContainer2.PaymentOrder.VatAmount);
        //}

        //[Fact]
        //public async Task CreateAndCancelPaymentOrder_ShouldThrowOperationNotAvailableException()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest();
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);

        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

        //    var transactionRequest = new TransactionRequest
        //    {
        //        Description = "ABC123",
        //        PayeeReference = "Cancelling parts of the total amount"
        //    };

        //    await Assert.ThrowsAsync<OperationNotAvailableException>(() => this.Sut.PaymentOrders.CancelPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, transactionRequest));
        //}

        //[Fact]
        //public async Task CancelPaymentOrder()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest();

        //    var paymentOrder = await PaymentOrder.Get("#edffddffd");
        //    var operation = paymentOrder.Operations[LinkRelation.CreatePaymentorderCancellation] as CancelOperation;
        //    var transactionRequest = new TransactionRequest
        //    {
        //        Description = "ABC123",
        //        PayeeReference = "Cancelling parts of the total amount"
        //    };
        //    var test = await operation.Execute(transactionRequest);

        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);

        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

        //    var transactionRequest = new TransactionRequest
        //    {
        //        Description = "ABC123",
        //        PayeeReference = "Cancelling parts of the total amount"
        //    };

        //    await Assert.ThrowsAsync<OperationNotAvailableException>(() => this.Sut.PaymentOrders.CancelPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, transactionRequest));
        //}



        //[Fact]
        //public async Task CreateAndAbortPaymentOrder_ShouldReturnAbortedState()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest();
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);

        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

        //    var orderResponseContainer = await this.Sut.PaymentOrders.AbortPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id);
        //    Assert.NotNull(orderResponseContainer);
        //    Assert.NotNull(orderResponseContainer.PaymentOrder);
        //    Assert.Equal("Aborted", orderResponseContainer.PaymentOrder.State.Value);
        //}

        //[Fact]
        //public async Task CreateAndCapturePaymentOrder_ShouldThrowNotYetAuthorizedException()
        //{
        //    var paymentOrderRequest = CreatePaymentOrderRequest(100000, 25000);
        //    var paymentOrderResponseContainer = await this.Sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequest, PaymentOrderExpand.All);

        //    Assert.NotNull(paymentOrderResponseContainer);
        //    Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

        //    var transactionRequest = new TransactionRequest
        //    {
        //        Amount = 10000,
        //        Description = "Description",
        //        PayeeReference = Guid.NewGuid().ToString(),
        //        VatAmount = 2500,
        //        OrderItems = new List<OrderItem>
        //        {
        //            new OrderItem
        //            {
        //                Reference = "p1",
        //                Name = "Product1",
        //                Type = "Product",
        //                Class = "ProductGroup1",
        //                ItemUrl = "https://example.com/products/123",
        //                ImageUrl = "https://example.com/products/123.jpg",
        //                Description = "Product 1 description",
        //                DiscountDescription = "Volume discount",
        //                Quantity = 4,
        //                QuantityUnit = "pcs",
        //                UnitPrice = 300,
        //                DiscountPrice = 200,
        //                VatPercent = 2500,
        //                Amount = 1000,
        //                VatAmount = 250
        //            },
        //            new OrderItem
        //            {
        //                Reference = "p2",
        //                Name = "Product2",
        //                Type = "Product",
        //                Class = "ProductGroup1",
        //                Description = "Product 2 description",
        //                DiscountDescription = "Volume discount",
        //                Quantity = 1,
        //                QuantityUnit = "pcs",
        //                UnitPrice = 500,
        //                VatPercent = 2500,
        //                Amount = 500,
        //                VatAmount = 125
        //            }
        //        }
        //    };
        //    await Assert.ThrowsAsync<PaymentNotYetAuthorizedException>(() => this.Sut.PaymentOrders.Capture(paymentOrderResponseContainer.PaymentOrder.Id, transactionRequest));
        //}

        //[Fact]
        //public async Task GetUnknownPaymentOrder_ShouldThrowCouldNotFindPaymentException()
        //{
        //    var id = "/psp/paymentorders/56a45c8a-9605-437a-fb80-08d742822747";
        //    await Assert.ThrowsAsync<CouldNotFindPaymentException>(() => this.Sut.PaymentOrders.GetPaymentOrder(id));
        //}

        //private PaymentOrderRequest CreatePaymentOrderRequest(long amount = 30000, long vatAmount = 7500)
        //{
        //    return new PaymentOrderRequest
        //    {
        //        Amount = amount,
        //        VatAmount = vatAmount,
        //        Currency = new CurrencyCode("SEK"),
        //        Description = "Description",
        //        Language = new Language("sv-SE"),
        //        UserAgent = "useragent",
        //        PayeeInfo = new PayeeInfo
        //        {
        //            PayeeId = "91a4c8e0-72ac-425c-a687-856706f9e9a1",
        //            PayeeReference = DateTime.Now.Ticks.ToString(),
        //        }
        //    };
        //}
    }
}