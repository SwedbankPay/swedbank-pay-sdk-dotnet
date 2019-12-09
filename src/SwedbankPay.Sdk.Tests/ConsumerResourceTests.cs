namespace SwedbankPay.Sdk.Tests
{
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Tests.TestBuilders;

    using System;
    using System.Threading.Tasks;

    using Xunit;


    public class ConsumerResourceTests : ResourceTestsBase
    {
        private readonly ConsumersRequestContainerBuilder consumerResourceRequestContainer = new ConsumersRequestContainerBuilder();

        [Fact]
        public async Task InitializeConsumer_ShouldReturn_TokenNotNull()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                                                                                .Build();
            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest);
            //ASSERT

            Assert.NotNull(consumer);
            Assert.NotNull(consumer.ConsumersResponse.Token);

        }

        [Fact]
        public async Task InitializeConsumer_ShouldReturn_NonEmptyToken()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();
            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest);
            //ASSERT

            Assert.NotNull(consumer);
            Assert.NotNull(consumer.ConsumersResponse.Token);
            Assert.NotEqual(string.Empty, consumer.ConsumersResponse.Token);
        }

        [Fact]
        public async Task InitializeConsumer_ReturnsNonEmptyOperationsCollection()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();

            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest);

            //ASSERT
            Assert.NotNull(consumer);
            Assert.NotNull(consumer.Operations);
            Assert.NotEmpty(consumer.Operations);

        }

        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentException_IfUriIsWhitespace()
        {
            //ARRANGE
            var url = " ";

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(url, () => this.Sut.Consumers.GetShippingDetails(url));
        }

        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentException_IfUriIsNull()
        {
            //ARRANGE
            string url = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(url, () => this.Sut.Consumers.GetShippingDetails(url));
        }

        [Fact]
        public async Task GetShippingDetails_ThrowsCouldNotGetShippingDetails_IfUriIsIncorrect()
        {
            //ARRANGE
            var uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<BadRequestException>(() => this.Sut.Consumers.GetShippingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentException_IfUriIsWhitespace()
        {
            //ARRANGE
            var url = " ";

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(url, () => this.Sut.Consumers.GetBillingDetails(url));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentException_IfUriIsNull()
        {
            //ARRANGE
            string url = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(url, () => this.Sut.Consumers.GetBillingDetails(url));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsCouldNotGetBillingDetails_IfUriIsIncorrect()
        {
            //ARRANGE
            var uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<BadRequestException>(() => this.Sut.Consumers.GetBillingDetails(uri));
        }
    }
}
