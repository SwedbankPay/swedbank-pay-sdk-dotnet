using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class PaymentOrderTests
    {
        [Fact]
        public async Task WhenSendingACaptureRequest_WeDoNotCrash_AndGiveAReasonableError()
        {
            var handler = new FakeDelegatingHandler();
            var client = new HttpClient(handler);
            var uri = new Uri("http://api.externalintegration.payex.com/psp/paymentorders/2d35afaa-4e5a-4930-0de5-08d7da0988bc", UriKind.Absolute);
            client.BaseAddress = uri;
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(@"{
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
            ""href"": ""https://api.externalintegration.payex.com/psp/creditcard/payments/cb2cc4a8-fd1b-4311-54df-08d7da081586/captures"",
            ""rel"": ""create-paymentorder-capture"",
            ""contentType"": ""application/json""
        }
    ]
}")
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

            var captureRequest = new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), new List<OrderItem>
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

            var sut = await PaymentOrder.Create(new PaymentOrderRequest(
            Operation.Initiate,
            new CurrencyCode("NOK"),
            new Amount(25767),
            new Amount(0),
            "test",
            "test",
            new System.Globalization.CultureInfo("no-nb"),
            false,
            new Urls(uri, new List<Uri> { uri }, uri, uri),
            new PayeeInfo(Guid.Empty, "test")
            ), client, string.Empty);

            await Assert.ThrowsAsync<HttpResponseException>(() => sut.Operations.Capture(captureRequest));
        }
    }
}
