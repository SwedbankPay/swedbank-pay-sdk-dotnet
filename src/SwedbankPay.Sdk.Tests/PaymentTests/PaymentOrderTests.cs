using System.Text.Json;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;
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
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/paid""
    },
    ""cancelled"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/cancelled""
    },
    ""reversed"": {
      ""id"": ""/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503/reversed""
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
      ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503"",
      ""rel"": ""update-order"",
      ""contentType"": ""application/json""
    },
    {
      ""method"": ""PATCH"",
      ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/9c0a36c7-10fc-4d3f-7ad9-08dbdb75f503"",
      ""rel"": ""abort"",
      ""contentType"": ""application/json""
    },
    {
      ""method"": ""GET"",
      ""href"": ""https://ecom.externalintegration.payex.com/checkout/d91be3c8bc5252c2b5268864665d40e21dcfa29f36150c8c5fd33225da57a6af?_tc_tid\u003d2f1d544192e730fa1d70891a59b22f92"",
      ""rel"": ""redirect-checkout"",
      ""contentType"": ""text/html""
    },
    {
      ""method"": ""GET"",
      ""href"": ""https://ecom.externalintegration.payex.com/checkout/client/d91be3c8bc5252c2b5268864665d40e21dcfa29f36150c8c5fd33225da57a6af?culture\u003dsv-SE\u0026_tc_tid\u003d2f1d544192e730fa1d70891a59b22f92"",
      ""rel"": ""view-checkout"",
      ""contentType"": ""application/javascript""
    }
  ]
}";
    
    private const string PaymentOrderResponse1 = @"{
    ""paymentOrder"": {
        ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84"",
        ""created"": ""2023-10-03T09:38:29.7565991Z"",
        ""updated"": ""2023-10-03T10:45:05.4862034Z"",
        ""operation"": ""Purchase"",
        ""status"": ""Paid"",
        ""currency"": ""SEK"",
        ""amount"": 98000,
        ""vatAmount"": 0,
        ""remainingReversalAmount"": 98000,
        ""description"": ""Test description"",
        ""initiatingSystemUserAgent"": ""swedbankpay-sdksamplesite-dotnet/1.0.0.0"",
        ""language"": ""sv-SE"",
        ""availableInstruments"": [
            ""CreditCard"",
            ""Invoice-PayExFinancingSe"",
            ""Swish"",
            ""CreditAccount-CreditAccountSe"",
            ""Trustly"",
            ""MobilePay"",
            ""GooglePay"",
            ""ClickToPay""
        ],
        ""implementation"": ""PaymentsOnly"",
        ""integration"": ""HostedView"",
        ""instrumentMode"": false,
        ""guestMode"": true,
        ""orderItems"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/orderitems"",
            ""orderItemList"": [
                {
                    ""reference"": ""P2"",
                    ""name"": ""Nike Metcon 5"",
                    ""type"": ""PRODUCT"",
                    ""class"": ""ProductGroup1"",
                    ""quantity"": 1.0000,
                    ""quantityUnit"": ""pcs"",
                    ""unitPrice"": 75000,
                    ""discountPrice"": 0,
                    ""vatPercent"": 0,
                    ""amount"": 75000,
                    ""vatAmount"": 0,
                    ""restrictedToInstruments"": []
                },
                {
                    ""reference"": ""P1"",
                    ""name"": ""Puma Black Sneakers Shoes"",
                    ""type"": ""PRODUCT"",
                    ""class"": ""ProductGroup1"",
                    ""quantity"": 1.0000,
                    ""quantityUnit"": ""pcs"",
                    ""unitPrice"": 23000,
                    ""discountPrice"": 0,
                    ""vatPercent"": 0,
                    ""amount"": 23000,
                    ""vatAmount"": 0,
                    ""restrictedToInstruments"": []
                }
            ]
        },
        ""urls"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/urls"",
            ""hostUrls"": [
                ""https://localhost:5001/""
            ],
            ""completeUrl"": ""https://localhost:5001/Checkout/Thankyou"",
            ""cancelUrl"": ""https://localhost:5001/Checkout/Aborted"",
            ""callbackUrl"": ""https://localhost:5001/Checkout/Callback"",
            ""paymentUrl"": ""https://localhost:5001/CheckOut/LoadPaymentMenu""
        },
        ""payeeInfo"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/payeeinfo""
        },
        ""payer"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/payers""
        },
        ""history"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/history"",
            ""historyList"": [
                {
                    ""created"": ""2023-10-03T09:38:29.7565991Z"",
                    ""name"": ""PaymentCreated"",
                    ""initiatedBy"": ""Merchant""
                },
                {
                    ""created"": ""2023-10-03T09:38:30.5390334Z"",
                    ""name"": ""PaymentLoaded"",
                    ""initiatedBy"": ""System""
                },
                {
                    ""created"": ""2023-10-03T10:44:10.2721998Z"",
                    ""name"": ""PaymentInstrumentSelected"",
                    ""instrument"": ""GooglePay"",
                    ""initiatedBy"": ""Payer""
                },
                {
                    ""created"": ""2023-10-03T10:44:14.1774001Z"",
                    ""name"": ""PaymentAttemptStarted"",
                    ""instrument"": ""GooglePay"",
                    ""prefill"": false,
                    ""initiatedBy"": ""Payer""
                },
                {
                    ""created"": ""2023-10-03T10:44:35.1882228Z"",
                    ""name"": ""PaymentInstrumentSelected"",
                    ""instrument"": ""Swish"",
                    ""initiatedBy"": ""Payer""
                },
                {
                    ""created"": ""2023-10-03T10:44:35.2507252Z"",
                    ""name"": ""PaymentAttemptAborted"",
                    ""instrument"": ""GooglePay"",
                    ""initiatedBy"": ""Payer""
                },
                {
                    ""created"": ""2023-10-03T10:45:05.4823577Z"",
                    ""name"": ""PaymentAttemptStarted"",
                    ""number"": 44100889705,
                    ""instrument"": ""Swish"",
                    ""prefill"": false,
                    ""initiatedBy"": ""Payer""
                },
                {
                    ""created"": ""2023-10-03T10:45:10.573019Z"",
                    ""name"": ""PaymentSaleCompleted"",
                    ""number"": 44100889705,
                    ""instrument"": ""Swish"",
                    ""initiatedBy"": ""Merchant""
                },
                {
                    ""created"": ""2023-10-03T10:45:10.573019Z"",
                    ""name"": ""PaymentPaid"",
                    ""number"": 44100889705,
                    ""instrument"": ""Swish"",
                    ""initiatedBy"": ""Payer""
                }
            ]
        },
        ""failed"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/failed""
        },
        ""aborted"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/aborted""
        },
        ""paid"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/paid"",
            ""instrument"": ""Swish"",
            ""number"": 44100889705,
            ""payeeReference"": ""638319299095650770"",
            ""transactionType"": ""Sale"",
            ""amount"": 98000,
            ""submittedAmount"": 98000,
            ""feeAmount"": 0,
            ""discountAmount"": 0,
            ""details"": {
                ""msisdn"": ""+46701234567""
            }
        },
        ""cancelled"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/cancelled""
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
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/failedattempts""
        },
        ""metadata"": {
            ""id"": ""/psp/paymentorders/1039d2c0-cf37-4611-6f61-08dbc01cba84/metadata""
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

    private const string PaymentOrderCancelResponse = @"
            {
                ""payment"": ""/psp/creditcard/payments/7e6cdfc3-1276-44e9-9992-7cf4419750e1"",
                ""cancellation"": {
                    ""id"": ""/psp/creditcard/payments/7e6cdfc3-1276-44e9-9992-7cf4419750e1/cancellations/ec2a9b09-601a-42ae-8e33-a5737e1cf177"",
                    ""transaction"": {
                        ""id"": ""/psp/creditcard/payments/7e6cdfc3-1276-44e9-9992-7cf4419750e1/transactions/ec2a9b09-601a-42ae-8e33-a5737e1cf177"",
                        ""created"": ""2022-01-31T09:49:13.7567756Z"",
                        ""updated"": ""2022-01-31T09:49:14.7374165Z"",
                        ""type"": ""Cancellation"",
                        ""state"": ""Completed"",
                        ""number"": 71100732065,
                        ""amount"": 1500,
                        ""vatAmount"": 375,
                        ""description"": ""Test Cancellation"",
                        ""payeeReference"": ""AB123""
                    }
                }
            }";

    private const string PaymentOrderReversalResponse = @"
            {
                ""payment"": ""/psp/creditcard/payments/09ccd29a-7c4f-4752-9396-12100cbfecce"",
                ""reversal"": {
                    ""id"": ""/psp/creditcard/payments/09ccd29a-7c4f-4752-9396-12100cbfecce/reversals/ec2a9b09-601a-42ae-8e33-a5737e1cf177"",
                    ""transaction"": {
                        ""id"": ""/psp/pcreditcard/payments/09ccd29a-7c4f-4752-9396-12100cbfecce/transactions/ec2a9b09-601a-42ae-8e33-a5737e1cf177"",
                        ""created"": ""2022-01-26T14:00:03.4725904Z"",
                        ""updated"": ""2022-01-26T14:00:04.3851302Z"",
                        ""type"": ""Reversal"",
                        ""state"": ""Completed"",
                        ""number"": 71100730898,
                        ""amount"": 1500,
                        ""vatAmount"": 375,
                        ""description"": ""Reversing the capture amount"",
                        ""payeeReference"": ""ABC123"",
                        ""receiptReference"": ""ABC122"",
                        ""isOperational"": false,
                        ""reconciliationNumber"": 738180,
                        ""operations"": []
                    }
                }
            }";

    private static Uri GetUri() => new Uri("http://api.externalintegration.payex.com/psp/paymentorders/2d35afaa-4e5a-4930-0de5-08d7da0988bc", UriKind.Absolute);

    private readonly PaymentOrderRequestBuilder _paymentOrderRequestBuilder = new();

    [Fact]
    public void CanDeserializePaymentOrder()
    {
        var paymentOrderResponseDto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(PaymentOrderResponse31, JsonSerialization.JsonSerialization.Settings);
        Assert.NotNull(paymentOrderResponseDto);
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList);
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList.FirstOrDefault());
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList.FirstOrDefault()?.OrderItems);
        Assert.NotNull(paymentOrderResponseDto.PaymentOrder.FinancialTransactions?.FinancialTransactionsList.FirstOrDefault()?.OrderItems.Id);
    }
    
    [Fact]
    public void CanSserializePaymentOrder()
    {
        var paymentOrderResponseDto = JsonSerializer.Deserialize<PaymentOrderResponseDto>(PaymentOrderResponse31, JsonSerialization.JsonSerialization.Settings);
        var paymentOrderResponse = new PaymentOrderResponse(paymentOrderResponseDto, new HttpClient());
        var serialize = JsonSerializer.Serialize(paymentOrderResponse, JsonSerialization.JsonSerialization.Settings);
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
        Assert.True(operationsUpdate.PaymentOrder.OrderItems.OrderItemList.Count() == 1);
    }

    [Fact]
    public async Task GetPaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE
        var paymentOrderUri = new Uri("/psp/paymentorders/cfea7191-c3e5-482a-1560-08dbc01c468e", UriKind.RelativeOrAbsolute);
        var handler = new FakeDelegatingHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = GetUri()
        };
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(PaymentOrderResponse31)
        });


        //ACT
        var paymentOrder = await new PaymentOrdersResource(client).Get(paymentOrderUri);
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
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(PaymentOrderResponse31)
        });
        handler.FakeResponseList.Add(new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
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

        var result = await Assert.ThrowsAsync<HttpResponseException>(() => sut.Operations.Capture(captureRequest));

        Assert.Equal(1, result.Data.Count);
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
            StatusCode = System.Net.HttpStatusCode.OK,
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
        var dto = JsonSerializer.Deserialize<PaymentOrderCancelResponseDto>(PaymentOrderCancelResponse, JsonSerialization.JsonSerialization.Settings);
        Assert.NotNull(dto);
        var sut = new PaymentOrderCancelResponse(dto);

        Assert.NotNull(sut);
        Assert.NotNull(sut.Cancellation);
        Assert.NotNull(sut.Cancellation.Transaction);
        Assert.NotNull(sut.Payment);
    }

    [Fact]
    public void CanDeSerialize_Reversal_WithNoErrors()
    {
        var dto = JsonSerializer.Deserialize<PaymentOrderReversalResponseDto>(PaymentOrderReversalResponse, JsonSerialization.JsonSerialization.Settings);
        Assert.NotNull(dto);
        var sut = new PaymentOrderReversalResponse(dto);

        Assert.NotNull(sut);
        Assert.NotNull(sut.Reversal);
        Assert.NotNull(sut.Reversal.Transaction);
        Assert.NotNull(sut.Payment);
    }


    private static PaymentOrderCaptureRequest GetTestPaymentOrderCaptureRequest()
    {
        var req = new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), "Capturing payment.", "637218522761159010", "receiptReference");
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
}