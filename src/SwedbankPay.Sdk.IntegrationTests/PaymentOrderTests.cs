using System.Net;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.Metadata;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;
using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.Tests;
using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.IntegrationTests;

public class PaymentOrderTests : ResourceTestsBase
{
    private readonly PaymentOrderRequestBuilder _paymentOrderRequestBuilder = new PaymentOrderRequestBuilder();

    [Fact]
    public async Task CreateAndAbortPaymentOrder_ShouldReturnAbortedState()
    {
        //ARRANGE

        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotEmpty(paymentOrder.Operations);
        Assert.NotNull(paymentOrder.Operations.Abort);

        var responseContainer = await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("testAbortReason"));

        Assert.NotNull(responseContainer);
        Assert.NotNull(responseContainer.PaymentOrder);
        Assert.Equal(Status.Aborted, responseContainer.PaymentOrder.Status);
    }



    [Fact]
    public async Task CreateAndGetPaymentOrder_ShouldReturnPaymentOrderWithSameAmountAndMetadata()
    {
        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).Build();
        paymentOrderRequest.Metadata = new Metadata
        {
            { "key1", "value1" }
        };
            
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.PaymentOrder);
        var amount = paymentOrder.PaymentOrder.Amount;

        var paymentOrder2 = await Sut.PaymentOrders.Get(paymentOrder.PaymentOrder.Id, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder2);
        Assert.NotNull(paymentOrder2.PaymentOrder);
        Assert.NotNull(paymentOrder2.PaymentOrder.Metadata);
        Assert.Equal(amount.InLowestMonetaryUnit, paymentOrder2.PaymentOrder.Amount.InLowestMonetaryUnit);

        Assert.Equal(paymentOrderRequest.Metadata["key1"], paymentOrder2.PaymentOrder.Metadata["key1"]);
    }


    [Fact]
    public async Task CreateAndUpdateOnlyAmountOnPaymentOrder_ShouldThrowHttpResponseException()
    {
        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.PaymentOrder);
        Assert.NotNull(paymentOrder.Operations.Update);

        var newAmount = 50000;
        var updateRequest = new PaymentOrderUpdateRequest(new Amount(newAmount), new Amount(0));

            
            
        await Assert.ThrowsAsync<HttpResponseException>(() => paymentOrder.Operations.Update?.Invoke(updateRequest)!);
    }

    [Fact]
    public async Task CreateAndUpdatePaymentOrder_WithOrderItems_ShouldNotThrowHttpResponseException()
    {
        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.PaymentOrder);
        Assert.NotNull(paymentOrder.Operations);
        Assert.NotNull(paymentOrder.Operations.Update);

        OrderItem updateOrderitem = new OrderItem("p3", "Product3", OrderItemType.Product, "ProductGroup3", 1, "pcs", 50000, 0,
            50000, 0)
        {
            ItemUrl = "https://example.com/products/1234",
            ImageUrl = "https://example.com/products/1234.jpg"
        };
        var updateRequest = new PaymentOrderUpdateRequest(updateOrderitem.Amount, updateOrderitem.VatAmount);
        updateRequest.PaymentOrder.OrderItems.Add(updateOrderitem);
        _ = await paymentOrder.Operations.Update.Invoke(updateRequest);
    }


    [Fact]
    public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrderWithNewAmounts()
    {
        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).Build();

        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.PaymentOrder);

        var newAmount = 50000;
        var newVatAmount = 10000;
        var updateRequest = new PaymentOrderUpdateRequest(new Amount(newAmount), new Amount(newVatAmount));
        Assert.NotNull(paymentOrder.Operations.Update);

        var response = await paymentOrder.Operations.Update(updateRequest);
            
        Assert.NotNull(response);
        Assert.NotNull(response.PaymentOrder);
        Assert.Equal(updateRequest.PaymentOrder.Amount, response.PaymentOrder.Amount);
        Assert.Equal(updateRequest.PaymentOrder.VatAmount, response.PaymentOrder.VatAmount);
    }

    [Fact]
    public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
    {
        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).Build();
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest);
            
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.PaymentOrder);
        Assert.Equal(paymentOrderRequest.Amount, paymentOrder.PaymentOrder.Amount);
    }


    [Fact]
    public async Task CreatePaymentOrder_WithOrderItems_ShouldReturnOrderItemsIfExpanded()
    {
        //ARRANGE
        var paymentOrderRequestContainer = _paymentOrderRequestBuilder.WithTestValues(PayeeId)
            .WithOrderItems()
            .Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequestContainer, PaymentOrderExpand.OrderItems);

        //ASSERT
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.PaymentOrder);
        Assert.Equal(UserAgent.Default, paymentOrder.PaymentOrder.InitiatingSystemUserAgent);
        Assert.NotNull(paymentOrder.PaymentOrder.OrderItems);
        Assert.NotNull(paymentOrder.PaymentOrder.OrderItems.OrderItemList);
        Assert.NotEmpty(paymentOrder.PaymentOrder.OrderItems.OrderItemList);
    }
        
    [Fact]
    public async Task GetUnknownPaymentOrder_ShouldThrowHttpResponseException()
    {
        var id = new Uri("/psp/paymentorders/56a45c8a-9605-437a-fb80-08d742822747", UriKind.Relative);

        var thrownException = await Assert.ThrowsAsync<HttpResponseException>(() => this.Sut.PaymentOrders.Get(id));
        Assert.Equal(HttpStatusCode.NotFound, thrownException.HttpResponse.StatusCode);
    }
}