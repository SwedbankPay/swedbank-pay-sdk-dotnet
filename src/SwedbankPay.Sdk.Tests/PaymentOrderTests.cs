using System.Text.Json;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;
using SwedbankPay.Sdk.Tests.TestBuilders;

namespace SwedbankPay.Sdk.Tests;

public class PaymentOrderTests : ResourceTestsBase
{
    private readonly PaymentOrderRequestBuilder paymentOrderRequestBuilder = new();

    private string _responseString =
        "{  \"paymentOrder\": {    \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84\",    \"created\": \"2023-10-02T17:20:02.2011373Z\",    \"updated\": \"2023-10-02T17:20:02.2329151Z\",    \"operation\": \"Purchase\",    \"status\": \"Initialized\",    \"currency\": \"SEK\",    \"amount\": 170000,    \"vatAmount\": 0,    \"description\": \"Test Description\",    \"initiatingSystemUserAgent\": \"swedbankpay-sdk-dotnet/1.0.0.0\",    \"language\": \"sv-SE\",    \"availableInstruments\": [      \"CreditCard\",      \"Invoice-PayExFinancingSe\",      \"Swish\",      \"CreditAccount-CreditAccountSe\",      \"Trustly\",      \"MobilePay\",      \"ApplePay\",      \"GooglePay\",      \"ClickToPay\"    ],    \"implementation\": \"PaymentsOnly\",    \"integration\": \"\",    \"instrumentMode\": false,    \"guestMode\": true,    \"orderItems\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/orderitems\",      \"orderItemList\": [        {          \"reference\": \"p1\",          \"name\": \"Product1\",          \"type\": \"PRODUCT\",          \"class\": \"ProductGroup1\",          \"itemUrl\": \"https://example.com/products/123\",          \"imageUrl\": \"https://example.com/products/123.jpg\",          \"quantity\": 4.0,          \"quantityUnit\": \"pcs\",          \"unitPrice\": 30000,          \"discountPrice\": 0,          \"vatPercent\": 0,          \"amount\": 120000,          \"vatAmount\": 0,          \"restrictedToInstruments\": []        },        {          \"reference\": \"p2\",          \"name\": \"Product2\",          \"type\": \"PRODUCT\",          \"class\": \"ProductGroup1\",          \"quantity\": 1.0,          \"quantityUnit\": \"pcs\",          \"unitPrice\": 50000,          \"discountPrice\": 0,          \"vatPercent\": 0,          \"amount\": 50000,          \"vatAmount\": 0,          \"restrictedToInstruments\": []        }      ]    },    \"urls\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/urls\",      \"hostUrls\": [        \"https://example.com/\"      ],      \"completeUrl\": \"https://example.com/payment-completed\",      \"cancelUrl\": \"https://example.com/payment-canceled\",      \"callbackUrl\": \"https://example.com/payment-callback\"    },    \"payeeInfo\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/payeeinfo\",      \"payeeId\": \"35a8a08f-f6d2-46ed-8f67-b94813d7c87d\",      \"payeeReference\": \"638318711988967230\",      \"payeeName\": \"Authority PaymentsOnly\",      \"merchantName\": \"Authority PaymentsOnly\",      \"corporationId\": \"d9245f4e-239e-4152-b1c3-601cba33f27b\",      \"corporationName\": \"Authority\",      \"salesChannel\": \"Online\"    },    \"payer\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/payers\"    },    \"history\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/history\"    },    \"failed\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/failed\"    },    \"aborted\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/aborted\"    },    \"paid\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/paid\"    },    \"cancelled\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/cancelled\"    },    \"financialTransactions\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/financialtransactions\"    },    \"failedAttempts\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/failedattempts\"    },    \"metadata\": {      \"id\": \"/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84/metadata\"    }  },  \"operations\": [    {      \"method\": \"PATCH\",      \"href\": \"https://api.externalintegration.payex.com/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84\",      \"rel\": \"update-order\",      \"contentType\": \"application/json\"    },    {      \"method\": \"PATCH\",      \"href\": \"https://api.externalintegration.payex.com/psp/paymentorders/4729785b-92ac-4cd4-6b08-08dbc01cba84\",      \"rel\": \"abort\",      \"contentType\": \"application/json\"    },    {      \"method\": \"GET\",      \"href\": \"https://ecom.externalintegration.payex.com/checkout/816452555a28543ad9e5025ae6dbaee5cb0b5bc72d6a41ca14c93b724d9ed62f?_tc_tid\\u003dd6c76b335e4644959818342b04c9ff66\",      \"rel\": \"redirect-checkout\",      \"contentType\": \"text/html\"    },    {      \"method\": \"GET\",      \"href\": \"https://ecom.externalintegration.payex.com/checkout/client/816452555a28543ad9e5025ae6dbaee5cb0b5bc72d6a41ca14c93b724d9ed62f?culture\\u003dsv-SE\\u0026_tc_tid\\u003dd6c76b335e4644959818342b04c9ff66\",      \"rel\": \"view-checkout\",      \"contentType\": \"application/javascript\"    }  ]}";

    [Fact]
    public async Task CanDeserializePaymentOrder()
    {
        var paymentOrderResponseDto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(_responseString, JsonSerialization.JsonSerialization.Settings);
    }

    [Fact]
    public async Task CreateAndAbortPaymentOrder_ShouldSetCorrectState()
    {
        //ARRANGE
        var paymentOrderRequest = paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
        Assert.NotNull(paymentOrder.Operations.Abort);

        var orderResponse = await paymentOrder.Operations.Abort.Invoke(new PaymentOrderAbortRequest("cancelerad"));
        Assert.NotNull(orderResponse);
        Assert.Equal("Aborted", orderResponse.PaymentOrder.Status);
    }

    [Fact]
    public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithView()
    {
        //ARRANGE

        var paymentOrderRequest = paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
        Assert.NotNull(paymentOrder.Operations.View);
    }


    [Fact]
    public async Task CreatePaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE

        var paymentOrderRequest = paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
    }
    
    
    [Fact]
    public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE

        var paymentOrderRequest = paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
        Assert.NotNull(paymentOrder.Operations.Update);

        var paymentOrderUpdateRequest = new PaymentOrderUpdateRequest(new Amount(20000), new Amount(0));
        var orderItems = new List<OrderItem>
        {
            new("p3", "Product3", OrderItemType.Product, "ProductGroup3", 4, "pcs", new Amount(5000), 0,
                new Amount(20000), new Amount(0))
            {
                ItemUrl = "https://example.com/products/123",
                ImageUrl = "https://example.com/products/123.jpg"
            }
        };

        foreach (var orderItem in orderItems)
        {
            paymentOrderUpdateRequest.PaymentOrder.OrderItems.Add(orderItem);
        }
        

        var operationsUpdate = await paymentOrder.Operations.Update(paymentOrderUpdateRequest);
        Assert.NotNull(operationsUpdate);
        Assert.NotNull(operationsUpdate.PaymentOrder);
        Assert.NotNull(operationsUpdate.PaymentOrder.OrderItems);
        Assert.True(operationsUpdate.PaymentOrder.OrderItems.OrderItemList.Count() == 1);
    }
    
    [Fact]
    public async Task GetPaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE

        var paymentOrderUri = new Uri("/psp/paymentorders/cfea7191-c3e5-482a-1560-08dbc01c468e", UriKind.RelativeOrAbsolute);

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Get(paymentOrderUri, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
        // Assert.NotNull(paymentOrder.Operations.Abort);
    }
    
}