using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Extensions;
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
        public async Task ApiError_DoesNotResultInWrongException_WhenDataIsSerialized()
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

            var error = await Assert.ThrowsAsync<HttpResponseException>(() => sut.SendAndProcessAsync<object>(HttpMethod.Get, uri, null));

            Assert.Equal(3, error.Data.Count);
        }
    }
}
