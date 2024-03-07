using System.Net;
using System.Text.Json;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Infrastructure.JsonSerialization;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;
using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.Tests.TestBuilders;
using SwedbankPay.Sdk.Tests.TestHelpers;

namespace SwedbankPay.Sdk.Tests.PaymentTests;

public class PaymentOrderTests : ResourceTestsBase
{
    private const string PaymentOrderResponse31 = @"{
  ""paymentOrder"": {
    ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503"",
    ""created"": ""2023-11-14T12:57:18.2196109Z"",
    ""updated"": ""2023-11-14T12:57:18.2416724Z"",
    ""operation"": ""Purchase"",
    ""status"": ""Initialized"",
    ""currency"": ""SEK"",
    ""amount"": 23000,
    ""vatAmount"": 0,
    ""description"": ""Test description"",
    ""initiatingSystemUserAgent"": ""swedbankpay-sdksamplesite-dotnet/1.0.0.0"",
    ""language"": ""sv-SE"",
    ""availableInstruments"": [
      ""CreditCard"",
      ""Swish"",
      ""Trustly""
    ],
    ""implementation"": ""PaymentsOnly"",
    ""integration"": """",
    ""instrumentMode"": false,
    ""guestMode"": true,
    ""orderItems"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/orderitems""
    },
    ""urls"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/urls""
    },
    ""payeeInfo"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/payeeinfo""
    },
    ""payer"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/payers""
    },
    ""history"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/history""
    },
    ""failed"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/failed""
    },
    ""aborted"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/aborted""
    },
    ""paid"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/paid"",
        ""number"": 40128554403,
        ""instrument"": ""CreditCard"",
        ""payeeReference"": ""638388382567231410"",
        ""orderReference"": ""PO-638388346589715940"",
        ""transactionType"": ""Authorization"",
        ""amount"": 75000,
        ""submittedAmount"": 75000,
        ""feeAmount"": 0,
        ""discountAmount"": 0,
        ""tokens"": [
            {
                ""type"": ""recurrence"",
                ""token"": ""8da454e7-1f34-4942-be19-4eb133ce22cf"",
                ""name"": ""551000******2347"",
                ""expiryDate"": ""11/2033""
            }
        ],
        ""details"": {
            ""nonPaymentToken"": ""fdf176f9-71a2-4d84-9885-6c08f3060272"",
            ""externalNonPaymentToken"": ""d812904c476550b474b6616adafea"",
            ""cardBrand"": ""MasterCard"",
            ""cardType"": ""Credit"",
            ""maskedPan"": ""551000******2347"",
            ""expiryDate"": ""11/2033"",
            ""issuerAuthorizationApprovalCode"": ""L24700"",
            ""acquirerTransactionType"": ""3DSECURE"",
            ""acquirerStan"": ""24700"",
            ""acquirerTerminalId"": ""40128554403"",
            ""acquirerTransactionTime"": ""2023-12-22T09:38:06.084Z"",
            ""transactionInitiator"": ""CARDHOLDER"",
            ""bin"": ""551000"",
            ""paymentAccountReference"": ""d812904c476550b474b6616adafea""
        }
    },
    ""cancelled"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/cancelled""
    },
    ""reversed"": {
        ""id"": ""/psp/paymentorders/5a89bf9b-4cee-42df-ef05-08dc003cdad5/reversed"",
        ""number"": 40128508922,
        ""instrument"": ""CreditCard"",
        ""payeeReference"": ""638386601473813240"",
        ""amount"": 300000,
        ""submittedAmount"": 300000,
        ""feeAmount"": 0,
        ""discountAmount"": 0,
        ""details"": {
            ""nonPaymentToken"": ""fe1c1960-697e-43cc-a099-b9e5b56b0f08"",
            ""externalNonPaymentToken"": ""92af358aede74eb51710de09b7055"",
            ""cardBrand"": ""Visa"",
            ""cardType"": ""Credit"",
            ""maskedPan"": ""476173******0416"",
            ""expiryDate"": ""11/2033"",
            ""issuerAuthorizationApprovalCode"": ""L24829"",
            ""acquirerTransactionType"": ""3DSECURE"",
            ""acquirerStan"": ""24829"",
            ""acquirerTerminalId"": ""40128508602"",
            ""acquirerTransactionTime"": ""2023-12-20T07:43:36.018Z"",
            ""transactionInitiator"": ""CARDHOLDER"",
            ""bin"": ""476173"",
            ""paymentAccountReference"": ""92af358aede74eb51710de09b7055""
        }
    },
    ""financialTransactions"": {
        ""id"": ""/psp/paymentorders/86ffa0c5-a06e-4b37-3a5e-08dbceb433dc/financialtransactions"",
        ""financialTransactionsList"": [
            {
                ""id"": ""/psp/paymentorders/86ffa0c5-a06e-4b37-3a5e-08dbceb433dc/financialtransactions/177a2a19-53d9-4cd2-a6d1-08dbcee5d067"",
                ""created"": ""2023-10-18T13:00:04.2548195Z"",
                ""updated"": ""2023-10-18T13:00:04.9478096Z"",
                ""type"": ""Capture"",
                ""number"": 40127366860,
                ""amount"": 23000,
                ""vatAmount"": 0,
                ""description"": ""Capturing the authorized payment"",
                ""payeeReference"": ""638332380039447680"",
                ""orderItems"": {
                    ""id"": ""/psp/paymentorders/86ffa0c5-a06e-4b37-3a5e-08dbceb433dc/financialtransactions/177a2a19-53d9-4cd2-a6d1-08dbcee5d067/orderitems""
                }
            }
        ]
    },
    ""failedAttempts"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/failedattempts""
    },
    ""postPurchaseFailedAttempts"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/postpurchasefailedattempts""
    },
    ""metadata"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/metadata""
    }
  },
""operations"": [
        {
            ""method"": ""PATCH"",
            ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce"",
            ""rel"": ""update-order"",
            ""contentType"": ""application/json""
        },
        {
            ""method"": ""PATCH"",
            ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce"",
            ""rel"": ""abort"",
            ""contentType"": ""application/json""
        },
        {
            ""method"": ""POST"",
            ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/cancellations"",
            ""rel"": ""cancel"",
            ""contentType"": ""application/json""
        },
        {
            ""method"": ""POST"",
            ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/captures"",
            ""rel"": ""capture"",
            ""contentType"": ""application/json""
        },
        {
            ""method"": ""POST"",
            ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/reversals"",
            ""rel"": ""reversal"",
            ""contentType"": ""application/json""
        },
        {
            ""method"": ""GET"",
            ""href"": ""https://ecom.externalintegration.payex.com/checkout/073115b6226e834dd9b1665771bae76223b4488429729155587de689555c5539?_tc_tid=30f2168171e142d38bcd4af2c3721959"",
            ""rel"": ""redirect-checkout"",
            ""contentType"": ""text/html""
        },
        {
            ""method"": ""GET"",
            ""href"": ""https://ecom.externalintegration.payex.com/checkout/core/js/px.checkout.client.js?token=073115b6226e834dd9b1665771bae76223b4488429729155587de689555c5539&culture=sv-SE&_tc_tid=30f2168171e142d38bcd4af2c3721959"",
            ""rel"": ""view-checkout"",
            ""contentType"": ""application/javascript""
        }
    ]
}";

    private const string PaymentOrderCancelResponse = @"{
  ""paymentOrder"": {
    ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d"",
    ""created"": ""2020-03-03T07:19:27.5636519Z"",
    ""updated"": ""2020-03-03T07:21:00.5605905Z"",
    ""operation"": ""Purchase"",
    ""status"": ""Cancelled"",
    ""currency"": ""SEK"",
    ""amount"": 1500,
    ""vatAmount"": 375,
    ""description"": ""Test Purchase"",
    ""initiatingSystemUserAgent"": ""<should be set by the system calling POST:/psp/paymentorders>"",
    ""language"": ""sv-SE"",
    ""availableInstruments"": [ ""CreditCard"", ""Invoice-PayExFinancingSe"", ""Invoice-PayMonthlyInvoiceSe"", ""Swish"", ""CreditAccount"", ""Trustly"" ],
    ""implementation"": ""PaymentsOnly"",
    ""integration"": ""HostedView|Redirect"",
    ""instrumentMode"": true,
    ""guestMode"": true,
    ""orderItems"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/orderitems""
    },
    ""urls"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/urls""
    },
    ""payeeInfo"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/payeeInfo""
    },
    ""payer"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/payers""
    },
    ""history"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/history""
    },
    ""failed"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/failed""
    },
    ""aborted"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/aborted""
    },
    ""paid"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/paid""
    },
    ""cancelled"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/cancelled""
    },
    ""financialTransactions"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/financialtransactions""
    },
    ""failedAttempts"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/failedattempts""
    },
    ""postpurchaseFailedAttempts"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/postpurchasefailedattempts""
    },
    ""metadata"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/metadata""
    }
  },
  ""operations"": [
  ]
}";

    private const string PaymentOrderReversalResponse = @"{
  ""paymentOrder"": {
    ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d"",
    ""created"": ""2020-03-03T07:19:27.5636519Z"",
    ""updated"": ""2020-03-03T07:21:00.5605905Z"",
    ""operation"": ""Purchase"",
    ""status"": ""Reversed"",
    ""currency"": ""SEK"",
    ""amount"": 1500,
    ""vatAmount"": 375,
    ""remainingCaptureAmount"": 0,
    ""remainingReversalAmount"": 0,
    ""description"": ""Test Purchase"",
    ""initiatingSystemUserAgent"": ""<should be set by the system calling POST:/psp/paymentorders>"",
    ""language"": ""sv-SE"",
    ""availableInstruments"": [ ""CreditCard"", ""Invoice-PayExFinancingSe"", ""Invoice-PayMonthlyInvoiceSe"", ""Swish"", ""CreditAccount"", ""Trustly"" ],
    ""implementation"": ""PaymentsOnly"",
    ""integration"": ""HostedView|Redirect"",
    ""instrumentMode"": true,
    ""guestMode"": true,
    ""orderItems"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/orderitems""
    },
    ""urls"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/urls""
    },
    ""payeeInfo"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/payeeInfo""
    },
    ""payer"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/payers""
    },
    ""history"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/history""
    },
    ""failed"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/failed""
    },
    ""aborted"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/aborted""
    },
    ""paid"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/paid""
    },
    ""cancelled"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/cancelled""
    },
    ""financialTransactions"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/financialtransactions""
    },
    ""failedAttempts"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/failedattempts""
    },
    ""postpurchaseFailedAttempts"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/postpurchasefailedattempts""
    },
    ""metadata"": {
      ""id"": ""/psp/paymentorders/8be318c1-1caa-4db1-e2c6-08d7bf41224d/metadata""
    }
  },
  ""operations"": [
  ]
}";

    private static Uri GetUri() => new("http://api.externalintegration.payex.com", UriKind.Absolute);

    private readonly PaymentOrderRequestBuilder _paymentOrderRequestBuilder = new();

    [Fact]
    public void CanDeserializePaymentOrder()
    {
        var paymentOrderResponseDto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(PaymentOrderResponse31,
            JsonSerialization.Settings);
        Assert.NotNull(paymentOrderResponseDto);
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList);
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList
            .FirstOrDefault());
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList
            .FirstOrDefault()?.OrderItems);
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList
            .FirstOrDefault()?.OrderItems?.Id);
    }

    [Fact]
    public void CanSerializePaymentOrder()
    {
        var paymentOrderResponseDto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(PaymentOrderResponse31,
            JsonSerialization.Settings);
        Assert.NotNull(paymentOrderResponseDto);
        var paymentOrderResponse = new PaymentOrderResponse(paymentOrderResponseDto, new HttpClient());
        JsonSerializer.Serialize(paymentOrderResponse, JsonSerialization.Settings);
    }

    [Fact]
    public async Task CreateAndAbortPaymentOrder_ShouldSetCorrectState()
    {
        //ARRANGE
        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

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

        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

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

        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
    }


    [Fact]
    public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE

        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

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
        Assert.NotNull(operationsUpdate.PaymentOrder.OrderItems.OrderItemList);
        Assert.True(operationsUpdate.PaymentOrder.OrderItems.OrderItemList.Count() == 1);
    }

    [Fact]
    public async Task GetPaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE
        var paymentOrderUri = new Uri("/psp/paymentorders/cfea7191-c3e5-482a-1560-08dbc01c468e",
            UriKind.RelativeOrAbsolute);
        var handler = new FakeDelegatingHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = GetUri()
        };
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(PaymentOrderResponse31)
        });


        //ACT
        var paymentOrder = await new PaymentOrdersResource(client).Get(paymentOrderUri);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
    }


    [Fact]
    public async Task GetPaymentOrder_ShouldReturnPaymentOrderReal()
    {
        //ARRANGE
        var paymentOrderUri = new Uri("/psp/paymentorders/894f7efb-8535-4c3f-ccd6-08dbf62d5f1c",
            UriKind.RelativeOrAbsolute);

        //ACT
        var paymentOrder = await Sut.PaymentOrders.Get(paymentOrderUri, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotNull(paymentOrder.Operations);
    }


    [Fact]
    public async Task WhenSendingACaptureRequest_WeDoNotCrash_AndGiveAReasonableError()
    {
        var handler = new FakeDelegatingHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = GetUri()
        };
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(PaymentOrderResponse31)
        });
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            Content = new StringContent(@"
            {
                ""sessionId"": ""27146bc5-269e-4b69-a25b-16308f4b481f"",
                ""type"": ""https://api.payex.com/psp/errordetail/forbidden"",
                ""title"": ""Operation not allowed"",
                ""status"": 403,
                ""instance"": ""http://api.externalintegration.payex.com/psp/paymentorders/74fa6203-e59a-43e0-0f44-08d7da0988bc/captures"",
                ""detail"": ""Payment check failed, description in problems node!"",
                ""problems"": [
                    {
                        ""name"": ""Capture"",
                        ""description"": ""Capture amount too high.""
                    }
                ]
            }
            ")
        });
        PaymentOrderCaptureRequest captureRequest = GetTestPaymentOrderCaptureRequest();

        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        var sut = await new PaymentOrdersResource(client).Create(paymentOrderRequest);

        var result =
            await Assert.ThrowsAsync<HttpResponseException>(() => sut!.Operations.Capture!.Invoke(captureRequest));

        Assert.Single(result.Data);
    }


    [Fact]
    public async Task CreatingACaptureRequest_Serailizes_AsExepceted()
    {
        var handler = new FakeDelegatingHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = GetUri()
        };
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(PaymentOrderResponse31)
        });

        var paymentOrderRequest = _paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        var sut = await new PaymentOrdersResource(client).Create(paymentOrderRequest);

        Assert.NotNull(sut);
        Assert.NotNull(sut.PaymentOrder);
        Assert.NotNull(sut.Operations);
        Assert.NotNull(sut.Operations.Abort);
        Assert.NotNull(sut.Operations.Cancel);
        Assert.NotNull(sut.Operations.Capture);
        Assert.NotNull(sut.Operations.Reverse);
        Assert.NotNull(sut.Operations.Update);
        Assert.NotNull(sut.Operations.View);
    }


    [Fact]
    public void CanDeSerialize_Cancel_WithNoErrors()
    {
        var dto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(PaymentOrderCancelResponse,
            JsonSerialization.Settings);
        Assert.NotNull(dto);
        var sut = new PaymentOrderResponse(dto, new HttpClient());

        Assert.NotNull(sut);
        Assert.NotNull(sut.PaymentOrder);
    }

    [Fact]
    public void CanDeSerialize_Reversal_WithNoErrors()
    {
        var dto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(PaymentOrderReversalResponse,
            JsonSerialization.Settings);
        Assert.NotNull(dto);
        var sut = new PaymentOrderResponse(dto, new HttpClient());

        Assert.NotNull(sut);
        Assert.NotNull(sut.PaymentOrder);
    }

    [Fact]
    public void CanDeserializeCallback()
    {
        string callback = @"{
            ""paymentOrder"": {
                ""id"": ""/psp/paymentorders/4b03d9e6-e75f-48a2-32d8-08dbff73f7a7"",
                ""instrument"": ""Swish"",
                ""number"": 44100921924
            }
        }";
        var callbackInfo =
            JsonSerializer.Deserialize<CallbackInfo>(callback,
                JsonSerialization.Settings);
        Assert.NotNull(callbackInfo);
        Assert.NotNull(callbackInfo.PaymentOrder);
    }


    private static PaymentOrderCaptureRequest GetTestPaymentOrderCaptureRequest()
    {
        var req = new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), "Capturing payment.",
            "637218522761159010");
        req.Transaction.OrderItems.Add(new OrderItem(
            "Test",
            "Test",
            OrderItemType.Other,
            "Capture",
            1,
            "pcs",
            new Amount(25767),
            0,
            new Amount(25767),
            new Amount(0)));

        return req;
    }

    [Fact]
    public void DeserializeGetTokensResponse()
    {
        var response = @"{
  ""payerOwnedTokens"": {
    ""id"": ""/psp/paymentorders/payerownedtokens/AB1234"",
    ""payerReference"": ""AB1234"",
    ""tokens"": [
      {
        ""tokenType"": ""Payment"",
        ""token"": ""82dcd804-5c32-4a00-ae7f-954491db438f"",
        ""correlationId"": ""3e4ed820-12c6-41b0-90f3-1d9d0e2d21ec"",
        ""instrument"": ""CreditCard"",
        ""instrumentDisplayName"": ""476173******0416"",
        ""instrumentParameters"": {
          ""expiryDate"": ""12/2024"",
          ""cardBrand"": ""Visa""
        },
        ""operations"": [
          {
            ""method"": ""PATCH"",
            ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/paymenttokens/82dcd804-5c32-4a00-ae7f-954491db438f"",
            ""rel"": ""delete-paymenttokens"",
            ""contentType"": ""application/json""
          }
        ]
      }
    ]
  },
  ""operations"": [
    {
      ""method"": ""PATCH"",
      ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/payerOwnedTokens/AB1234"",
      ""rel"": ""delete-payerownedtokens"",
      ""contentType"": ""application/json""
    }
  ]
}
";

        var dto = JsonSerializer.Deserialize<UserTokenListResponseDto>(response, JsonSerialization.Settings);
        Assert.NotNull(dto);
    }


    [Fact]
    public void DeserializeRemoveTokenResp()
    {
        var response = @"{
  ""payerOwnedTokens"": {
    ""id"": ""/psp/paymentorders/payerownedtokens/AB1234"",
    ""payerReference"": ""AB1234"",
    ""tokens"": [
      {
        ""tokenType"": ""Payment"",
        ""token"": ""d52ae770-2cb8-4f41-9aad-c6f5259f5b53"",
        ""correlationId"": ""3e4ed820-12c6-41b0-90f3-1d9d0e2d21ec"",
        ""instrument"": ""CreditCard"",
        ""instrumentDisplayName"": ""476173******0416"",
        ""instrumentParameters"": {
          ""expiryDate"": ""12/2024"",
          ""cardBrand"": ""Visa""
        }
      },
      {
        ""tokenType"": ""Recurrence"",
        ""token"": ""5327ef8f-8121-4155-a831-7c30e3a6d959"",
        ""correlationId"": ""c15a032f-2c31-4c8a-b6eb-f33097829b46"",
        ""instrument"": ""CreditCard"",
        ""instrumentDisplayName"": ""551000******2347"",
        ""instrumentParameters"": {
          ""expiryDate"": ""11/2033"",
          ""cardBrand"": ""MasterCard""
        }
      }
    ]
  }
}";

        var dtoResp = JsonSerializer.Deserialize<UserTokenResponseDto>(response, JsonSerialization.Settings);
        Assert.NotNull(dtoResp);

        var resp = new UserTokenResponse(dtoResp, new HttpClient());
        Assert.NotNull(resp);
    }
}