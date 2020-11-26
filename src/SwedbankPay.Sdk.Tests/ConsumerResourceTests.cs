using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests
{
    public class ConsumerResourceTests : ResourceTestsBase
    {
        private readonly ConsumersRequestContainerBuilder consumerResourceRequestContainer = new ConsumersRequestContainerBuilder();

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentNullException_IfUriIsNull()
        {
            //ARRANGE
            Uri url = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>(nameof(url), () => this.Sut.Consumers.GetBillingDetails(url));
        }


        [Fact]
        public async Task GetBillingDetails_ThrowsHttpRequestException_IfUriIsIncorrect()
        {
            //ARRANGE
            var uri = new Uri("http://xxx");

            //ASSERT
            await Assert.ThrowsAsync<HttpRequestException>(() => this.Sut.Consumers.GetBillingDetails(uri));
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentNullException_IfUriIsNull()
        {
            //ARRANGE
            Uri url = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>(nameof(url), () => this.Sut.Consumers.GetShippingDetails(url));
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsHttpRequestException_IfUriIsIncorrect()
        {
            //ARRANGE
            var uri = new Uri("http://xxx");

            //ASSERT
            await Assert.ThrowsAsync<HttpRequestException>(() => this.Sut.Consumers.GetShippingDetails(uri));
        }


        [Fact]
        public async Task EmptyShippingAddressRestrictedToCountryCodes_ShouldThrow_HttpResponseException()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues().WithEmptyShippingAddressCountryCodes()
                .Build();

            //ASSERT
            await Assert.ThrowsAsync<HttpResponseException>(() => this.Sut.Consumers.InitiateSession(orderResoureRequest));

        }


        [Fact]
        public void DeSerializingConsumerResponse_ShouldReturn_ConsumerResponse()
        {
            var tokenString = @"{
    ""token"": ""4d47836d3d1830da8e98d98919c495bb3051db045f711863ebb11e8cc1b69034"",
    ""operations"": [
        {
            ""method"": ""GET"",
            ""rel"": ""redirect-consumer-identification"",
            ""href"": ""https://ecom.externalintegration.payex.com/consumers/sessions/4d47836d3d1830da8e98d98919c495bb3051db045f711863ebb11e8cc1b69034"",
            ""contentType"": ""text/html""
        },
        {
            ""method"": ""GET"",
            ""rel"": ""view-consumer-identification"",
            ""href"": ""https://ecom.externalintegration.payex.com/consumers/core/scripts/client/px.consumer.client.js?token=4d47836d3d1830da8e98d98919c495bb3051db045f711863ebb11e8cc1b69034"",
            ""contentType"": ""application/javascript""
        }
    ]
}";
            var consumer = JsonSerializer.Deserialize<ConsumersResponseDto>(tokenString, JsonSerialization.JsonSerialization.Settings);
            Assert.NotNull(consumer);
            Assert.NotNull(consumer.Operations);
            Assert.NotNull(consumer.Token);
        }
    }
}
