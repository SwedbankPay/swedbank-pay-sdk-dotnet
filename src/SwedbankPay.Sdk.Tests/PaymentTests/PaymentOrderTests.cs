using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class PaymentOrderTests
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

        private static Uri GetUri() => new Uri("http://api.externalintegration.payex.com/psp/paymentorders/2d35afaa-4e5a-4930-0de5-08d7da0988bc", UriKind.Absolute);

        private static PaymentOrderCaptureRequest GetTestPaymentOrderCaptureRequest()
        {
            return new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), new List<OrderItem>
            {
                new OrderItem(
                    "Test",
                    "Test",
                    OrderItemType.Other,
                    "Capture",
                    1,
                    "pcs",
                    new Amount(25767),
                    0,
                    new Amount(25767),
                    new Amount(0))
            }, "Capturing payment.", "637218522761159010");
        }

        private static PaymentOrderRequest GetPaymentOrderRequest() => new PaymentOrderRequest(
            Operation.Initiate,
            new CurrencyCode("NOK"),
            new Amount(25767),
            new Amount(0),
            "test",
            "test",
            new Language("no-nb"),
            false,
            new Urls(new UrlsDto() { 
                Id = GetUri(),
                HostUrls = new List<Uri> { GetUri() },
                CallbackUrl = GetUri(),
                CompleteUrl = GetUri()
            }),
            new PayeeInfo(Guid.Empty, "test")
            );

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
    }
}
