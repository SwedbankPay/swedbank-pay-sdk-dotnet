using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using SwedbankPay.Sdk.Tests.TestHelpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.UnitTests
{
    public class HttpClientExtensionsTests : ResourceTestsBase
    {
        [Fact]
        public async Task ApiError_AreCorrectlySerialized_WithCorrectAmountOfDataAdded()
        {
            var client = new HttpClient();
            var paymentRequest = new PaymentRequestBuilder().WithCreditcardTestValues(this.payeeId, Operation.Verify).BuildCreditardPaymentRequest();
            var uri = new Uri("https://api.externalintegration.payex.com/psp/paymentorders/2d35afaa-4e5a-4930-0de5-08d7da0988bc");

            var error = await Assert.ThrowsAsync<HttpResponseException>(() => client.SendAndProcessAsync<object>(HttpMethod.Post, uri, paymentRequest));

            Assert.Equal(3, error.Data.Count);
        }

        [Fact]
        public async Task ProblemResponse_CorrectlySerializes_WithNoAdditionalErrors()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(@"{
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
                }")
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            var sut = new HttpClient(handler);

            var error = await Assert.ThrowsAsync<HttpResponseException>(() => sut.SendAndProcessAsync<ProblemResponse>(HttpMethod.Get, uri, null));

            Assert.Equal(3, error.Data.Count);
        }

        [Fact]
        public async Task ProblemResponse_CorrectlySerialzes_WhenApiReturnsWrongStatusCode()
        {
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(@"{
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
                }")
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            var sut = new HttpClient(handler);

            var result = await sut.SendAndProcessAsync<ProblemResponse>(HttpMethod.Get, uri, null);

            Assert.IsType<ProblemResponse>(result);
        }

        [Fact]
        public async Task WhenSendingACapture_TheConverter_HasZeroErrors()
        {
            var captureRespone = new CaptureResponse
                (new Uri("/psp/invoice/payments/7482db67-d2d8-4881-79d9-08d7dad1a06b", UriKind.Relative),
                new TransactionResponse(new Uri("/psp/invoice/payments/7482db67-d2d8-4881-79d9-08d7dad1a06b/captures/d07e17bf-8664-4664-fade-08d7dace174a", UriKind.Relative),
                new Transaction(new Uri("/psp/invoice/payments/7482db67-d2d8-4881-79d9-08d7dad1a06b/captures/d07e17bf-8664-4664-fade-08d7dace174a", UriKind.Relative),
                                DateTime.Now,
                                DateTime.Now,
                                TransactionType.Capture,
                                State.Completed,
                                71100590865,
                                new Amount(25767),
                                new Amount(0),
                                "Description",
                                "637218522761159010",
                                false,
                                new OperationList(),
                                string.Empty)));
            var handler = new FakeDelegatingHandler();
            handler.FakeResponseList.Add(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(captureRespone, JsonSerialization.JsonSerialization.Settings))
            });
            var uri = new Uri("http://api.externalintegration.payex.com");
            

            var captureRequest = new PaymentOrderCaptureRequest(new Amount(25767), new Amount(0), new System.Collections.Generic.List<OrderItem>
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

            var sut = new HttpClient(handler);
            var error = await Assert.ThrowsAsync<HttpResponseException>(() => sut.SendAndProcessAsync<CaptureResponse>(HttpMethod.Get, uri, captureRequest));

            Assert.Equal(3, error.Data.Count);
        }
    }
}
