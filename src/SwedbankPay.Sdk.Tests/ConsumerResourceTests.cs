using System;
using System.Net.Cache;
using System.Net.Http;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Tests.TestBuilders;

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
            string url = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>($"{url} Cannot be null or whitespace", () => this.Sut.Consumers.GetBillingDetails(url));
        }


        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentNullException_IfUriIsWhitespace()
        {
            //ARRANGE
            var url = " ";

            //ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>($"{url} Cannot be null or whitespace", () => this.Sut.Consumers.GetBillingDetails(url));
        }


        [Fact]
        public async Task GetBillingDetails_ThrowsHttpRequestException_IfUriIsIncorrect()
        {
            //ARRANGE
            var uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<HttpRequestException>(() => this.Sut.Consumers.GetBillingDetails(uri));
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentNullException_IfUriIsNull()
        {
            //ARRANGE
            string url = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>($"{url} Cannot be null or whitespace", () => this.Sut.Consumers.GetShippingDetails(url));
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentNullException_IfUriIsWhitespace()
        {
            //ARRANGE
            var url = " ";

            //ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>($"{url} Cannot be null or whitespace", () => this.Sut.Consumers.GetShippingDetails(url));
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsHttpRequestException_IfUriIsIncorrect()
        {
            //ARRANGE
            var uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<HttpRequestException>(() => this.Sut.Consumers.GetShippingDetails(uri));
        }


        [Fact]
        public async Task InitializeConsumer_ReturnsNonEmptyOperationsCollection()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();

            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest);

            //ASSERT
            Assert.NotNull(consumer);
            Assert.NotNull(consumer.Operations);
            Assert.NotEmpty(consumer.Operations);
        }


        [Fact]
        public async Task InitializeConsumer_ShouldReturn_NonEmptyToken()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();
            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest);
            //ASSERT

            Assert.NotNull(consumer);
            Assert.NotNull(consumer.ConsumersResponse.Token);
            Assert.NotEqual(string.Empty, consumer.ConsumersResponse.Token);
        }


        [Fact]
        public async Task InitializeConsumer_ShouldReturn_TokenNotNull()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();
            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest);
            //ASSERT

            Assert.NotNull(consumer);
            Assert.NotNull(consumer.ConsumersResponse.Token);
        }
    }
}