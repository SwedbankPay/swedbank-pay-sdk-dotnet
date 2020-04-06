using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
    }
}
