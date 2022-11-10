using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests;

public class PaymentOrderTests : ResourceTestsBase
{
    private const string PaymentOrderResponse = @"{
    ""paymentOrder"": {
        ""id"": ""/psp/paymentorders/3fec8ccd-d0aa-4bb6-babe-08d7da09db3c"",
        ""created"": ""2020-04-07T12:10:36.212828Z"",
        ""updated"": ""2020-04-07T12:11:00.434324Z"",
        ""operation"": ""Purchase"",
        ""state"": ""Ready"",
        ""currency"": ""SEK"",
        ""amount"": 1001,
        ""vatAmount"": 0,
        ""remainingCaptureAmount"": 1001,
        ""remainingCancellationAmount"": 1001,
        ""description"": ""test description"",
        ""initiatingSystemUserAgent"": ""Mozilla/5.0"",
        ""userAgent"": ""Mozilla/5.0"",
        ""language"": ""sv-SE"",
        ""urls"": {
            ""id"": ""/psp/paymentorders/3fec8ccd-d0aa-4bb6-babe-08d7da09db3c/urls""
        },
        ""payeeInfo"": {
            ""id"": ""/psp/paymentorders/3fec8ccd-d0aa-4bb6-babe-08d7da09db3c/payeeInfo""
        },
        ""payments"": {
            ""id"": ""/psp/paymentorders/3fec8ccd-d0aa-4bb6-babe-08d7da09db3c/payments""
        },
        ""currentPayment"": {
            ""id"": ""/psp/paymentorders/3fec8ccd-d0aa-4bb6-babe-08d7da09db3c/currentpayment""
        },
        ""items"": [
            {
                ""creditCard"": {
                    ""cardBrands"": [
                        ""Visa"",
                        ""MasterCard"",
                        ""Amex"",
                        ""Dankort"",
                        ""Diners"",
                        ""Finax"",
                        ""Forbrugsforeningen"",
                        ""Jcb"",
                        ""IkanoFinansDk"",
                        ""Lindex"",
                        ""Maestro"",
                        ""Ica""
                    ]
                }
            }
        ]
    },
    ""operations"": [
        {
    ""method"": ""POST"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/cancellations"",
    ""rel"": ""create-paymentorder-cancel"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""POST"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/captures"",
    ""rel"": ""create-paymentorder-capture"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""PATCH"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce"",
    ""rel"": ""update-paymentorder-overchargedamount"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""POST"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/cancellations"",
    ""rel"": ""create-cancellation"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""POST"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/captures"",
    ""rel"": ""create-capture"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""PATCH"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/authorizations/ea979760-ec45-4f23-14e3-08d7dade87af"",
    ""rel"": ""update-authorization-overchargedamount"",
    ""contentType"": ""application/json""
  },
  {
      ""method"": ""PATCH"",
      ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce"",
      ""rel"": ""update-paymentorder-abort"",
      ""contentType"": ""application/json""
  },
  {
      ""method"": ""PATCH"",
      ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce"",
      ""rel"": ""create-paymentorder-reversal"",
      ""contentType"": ""application/json""
  },
  {
    ""method"": ""GET"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/paid"",
    ""rel"": ""paid-paymentorder"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""PATCH"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce"",
    ""rel"": ""update-paymentorder-updateorder"",
    ""contentType"": ""application/json""
  },
  {
    ""method"": ""GET"",
    ""href"": ""https://api.externalintegration.payex.com/psp/paymentorders/09ccd29a-7c4f-4752-9396-12100cbfecce/javaScriptReference"",
    ""rel"": ""view-paymentorder"",
    ""contentType"": ""application/json""
  }
    ]
}";

    private const string PaymentOrderCancelResponse = @"{
    ""payment"": ""/psp/creditcard/payments/449fcc10-e73f-430a-3a1a-08d884bfe202"",
    ""cancellation"": {
        ""id"": ""/psp/creditcard/payments/449fcc10-e73f-430a-3a1a-08d884bfe202/cancellations/9b9da251-67e6-4466-38d3-08d884c0c381"",
        ""transaction"": {
            ""id"": ""/psp/creditcard/payments/449fcc10-e73f-430a-3a1a-08d884bfe202/transactions/9b9da251-67e6-4466-38d3-08d884c0c381"",
            ""created"": ""2020-11-10T14:04:45.5892823Z"",
            ""updated"": ""2020-11-10T14:04:45.6937756Z"",
            ""type"": ""Cancellation"",
            ""state"": ""Completed"",
            ""number"": 70100597193,
            ""amount"": 5000,
            ""vatAmount"": 0,
            ""description"": ""Test Cancellation"",
            ""payeeReference"": ""someUniqueReference1605017083"",
            ""isOperational"": false,
            ""operations"": []
        }
    }
}";

    private const string PaymentOrderReversalResponse = @"{
    ""payment"": ""/psp/creditcard/payments/449fcc10-e73f-430a-3a1a-08d884bfe202"",
    ""reversal"": {
        ""id"": ""/psp/creditcard/payments/449fcc10-e73f-430a-3a1a-08d884bfe202/reversals/396f4d54-3780-4cb0-ef75-08d884c39d47"",
        ""transaction"": {
            ""id"": ""/psp/creditcard/payments/449fcc10-e73f-430a-3a1a-08d884bfe202/transactions/396f4d54-3780-4cb0-ef75-08d884c39d47"",
            ""created"": ""2020-11-10T14:04:28.5615072Z"",
            ""updated"": ""2020-11-10T14:04:28.8787354Z"",
            ""type"": ""Reversal"",
            ""state"": ""Completed"",
            ""number"": 70100597192,
            ""amount"": 2500,
            ""vatAmount"": 0,
            ""description"": ""description for transaction"",
            ""payeeReference"": ""someUniqueReference1605017066"",
            ""isOperational"": false,
            ""operations"": []
        }
    }
}";

    private static Uri GetUri() => new Uri("http://api.externalintegration.payex.com/psp/paymentorders/2d35afaa-4e5a-4930-0de5-08d7da0988bc", UriKind.Absolute);
    private static Uri UriForTesting() => new Uri("https://localhost:5001", UriKind.RelativeOrAbsolute);

    private static PaymentOrderCaptureRequest GetTestPaymentOrderCaptureRequest()
    {
        var req = new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), "Capturing payment.", "637218522761159010");
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

    private PaymentOrderRequest GetPaymentOrderRequest() => new PaymentOrderRequest(
        Operation.Purchase,
        new Currency("NOK"),
        new Amount(25767),
        new Amount(0),
        "test",
        "test",
        new Language("no-nb"),
        false,
        new UrlsResponse(new UrlsDto
        {
            Id = UriForTesting().OriginalString,
            HostUrls = new List<Uri> { UriForTesting() },
            CallbackUrl = UriForTesting(),
            CompleteUrl = UriForTesting(),
            TermsOfServiceUrl = UriForTesting(),
            PaymentUrl = UriForTesting()
        }),
        new PayeeInfo(this.payeeId, GeneratePayeeReference())
        );

    private string GeneratePayeeReference()
    {
        var s = Guid.NewGuid().ToString();
        s = s.Replace("-", "");
        if (s.Length > 30)
        {
            s = s.Substring(0, 30);
        }

        return s;
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
            Content = new StringContent(PaymentOrderResponse)
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
        PaymentOrderRequest paymentOrderRequest = GetPaymentOrderRequest();

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
            Content = new StringContent(PaymentOrderResponse)
        });

        PaymentOrderRequest paymentOrderRequest = GetPaymentOrderRequest();

        var sut = await new PaymentOrdersResource(client).Create(paymentOrderRequest);

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
        var dto = JsonSerializer.Deserialize<CancelResponseDto>(PaymentOrderCancelResponse, JsonSerialization.JsonSerialization.Settings);
        var sut = new CancellationResponse(dto.Payment, dto.Cancellation.Map());

        Assert.NotNull(sut);
        Assert.NotNull(sut.Cancellation);
        Assert.NotNull(sut.Cancellation.Transaction);
        Assert.NotNull(sut.Payment);
    }

    [Fact]
    public void CanDeSerialize_Reversal_WithNoErrors()
    {
        var dto = JsonSerializer.Deserialize<ReversalResponseDto>(PaymentOrderReversalResponse, JsonSerialization.JsonSerialization.Settings);
        var sut = new ReversalResponse(dto.Payment, dto.Reversal.Map());

        Assert.NotNull(sut);
        Assert.NotNull(sut.Reversal);
        Assert.NotNull(sut.Reversal.Transaction);
        Assert.NotNull(sut.Payment);
    }
}
