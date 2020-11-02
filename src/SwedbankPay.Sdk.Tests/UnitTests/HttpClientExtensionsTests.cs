using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Tests.TestBuilders;
using SwedbankPay.Sdk.Tests.TestHelpers;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Xunit;

namespace SwedbankPay.Sdk.Tests.UnitTests
{
    public class HttpClientExtensionsTests : ResourceTestsBase
    {
        private const string PaymentOrderInputValidationFailedReponse = @"{
            ""sessionId"": ""09ccd29a-7c4f-4752-9396-12100cbfecce"",
            ""type"": ""https://api.payex.com/psp/errordetail/inputerror"",
            ""title"": ""Error in input data"",
            ""status"": 400,
            ""instance"": ""http://api.externalintegration.payex.com/psp/09ccd29a-7c4f-4752-9396-12100cbfecce/captures"",
            ""detail"": ""Input validation failed, error description in problems node!"",
            ""problems"": [
                {
                    ""name"": ""Transaction.Amount"",
                    ""description"": ""  ""
                }
            ]
        }";

        private const string PaymentCompletedReponse = @"{
            ""payment"": ""/psp/invoice/payments/09ccd29a-7c4f-4752-9396-12100cbfecce"",
            ""capture"": {
                ""itemDescriptions"": {
                    ""id"": ""/psp/invoice/payments/09ccd29a-7c4f-4752-9396-12100cbfecce/transactions/d07e17bf-8664-4664-fade-08d7dace174a/itemdescriptions""
                },
                ""id"": ""/psp/invoice/payments/09ccd29a-7c4f-4752-9396-12100cbfecce/captures/d07e17bf-8664-4664-fade-08d7dace174a"",
                ""transaction"": {
                    ""id"": ""/psp/invoice/payments/09ccd29a-7c4f-4752-9396-12100cbfecce/transactions/d07e17bf-8664-4664-fade-08d7dace174a"",
                    ""created"": ""2020-04-07T08:57:05.7367464Z"",
                    ""updated"": ""2020-04-07T08:57:07.1111552Z"",
                    ""type"": ""Capture"",
                    ""state"": ""Completed"",
                    ""number"": 71100590865,
                    ""amount"": 2,
                    ""vatAmount"": 0,
                    ""description"": ""description"",
                    ""payeeReference"": ""637218522761159010"",
                    ""isOperational"": false,
                    ""reconciliationNumber"": 0001,
                    ""operations"": []
                }
            }
        }";

        private static PaymentOrderCaptureRequest GetPaymentOrderCaptureRequest()
        {
            return new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), new System.Collections.Generic.List<OrderItem>
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

        [Fact]
        public async Task ApiError_AreCorrectlySerialized_WithCorrectAmountOfDataAdded()
        {
            var client = new HttpClient();
            var paymentRequest = new PaymentRequestBuilder().WithCreditcardTestValues(this.payeeId, Operation.Verify).BuildCreditardPaymentRequest();
            var uri = new Uri("https://api.externalintegration.payex.com/psp/paymentorders/2d35afaa-4e5a-4930-0de5-08d7da0988bc");

            var error = await Assert.ThrowsAsync<HttpResponseException>(() => client.SendAndProcessAsync<object>(HttpMethod.Post, uri, paymentRequest));

            Assert.Equal(1, error.Data.Count);
        }

        [Fact]
        public async Task ProblemResponse_CorrectlySerializes_WithNoAdditionalErrors()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(PaymentOrderInputValidationFailedReponse)
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            var sut = new HttpClient(handler);

            var error = await Assert.ThrowsAsync<HttpResponseException>(() => sut.SendAndProcessAsync<ProblemResponse>(HttpMethod.Get, uri, null));

            Assert.Equal(1, error.Data.Count);
        }

        [Fact]
        public async Task ProblemResponseException_CanBeSerialized_AsJson()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(PaymentOrderInputValidationFailedReponse)
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            var sut = new HttpClient(handler);

            var error = await Assert.ThrowsAsync<HttpResponseException>(() => sut.SendAndProcessAsync<ProblemResponse>(HttpMethod.Get, uri, null));

            JsonSerializer.Serialize(error);
        }

        [Fact]
        public async Task ProblemResponse_CorrectlySerialzes_WhenApiReturnsWrongStatusCode()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(PaymentOrderInputValidationFailedReponse)
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            var sut = new HttpClient(handler);

            var result = await sut.SendAndProcessAsync<ProblemResponse>(HttpMethod.Get, uri, null);

            Assert.IsType<ProblemResponse>(result);
        }

        [Fact]
        public async Task WhenSendingACapture_TheConverter_HasZeroErrors()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(PaymentCompletedReponse)
            });
            var uri = new Uri("http://api.externalintegration.payex.com");

            var sut = new HttpClient(handler);
            await sut.SendAndProcessAsync<CaptureResponse>(HttpMethod.Get, uri, GetPaymentOrderCaptureRequest());
        }

        [Fact]
        public async Task SendAndPrcoess_DoesNotFail_WhenNotExpectingError()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(PaymentOrderInputValidationFailedReponse)
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            var sut = new HttpClient(handler);

            var result = await Assert.ThrowsAsync<HttpResponseException>(() => sut.SendAndProcessAsync<CaptureResponse>(HttpMethod.Get, uri, new object()));

            Assert.Equal(1, result.Data.Count);
        }
    }
}
