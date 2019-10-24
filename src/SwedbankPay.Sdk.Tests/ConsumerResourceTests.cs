namespace SwedbankPay.Sdk.Tests
{
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Tests.TestBuilders;

    using System;
    using System.Threading.Tasks;

    using Xunit;


    public class ConsumerResourceTests : ResourceTestsBase
    {
        private readonly ConsumersRequestContainerBuilder _consumerResourceRequestContainer = new ConsumersRequestContainerBuilder(); 
       
        [Fact]
        public async Task InitializeConsumer_ShouldReturn_TokenNotNull()
        {
            //ARRANGE
            var orderResoureRequest = _consumerResourceRequestContainer.WithTestValues()
                                                                                .Build();
            //ACT
            var orderResourceResponse = await _sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest);
            //ASSERT
            
            Assert.NotNull(orderResourceResponse);
            Assert.NotNull(orderResourceResponse.Token);
            
        }

        [Fact]
        public async Task InitializeConsumer_ShouldReturn_NonEmptyToken()
        {
            //ARRANGE
            var orderResoureRequest = _consumerResourceRequestContainer.WithTestValues()
                .Build();
            //ACT
            var orderResourceResponse = await _sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest);
            //ASSERT

            Assert.NotNull(orderResourceResponse);
            Assert.NotNull(orderResourceResponse.Token);
            Assert.NotEqual(string.Empty, orderResourceResponse.Token);
        }
        [Fact]
        public async Task InitializeConsumer_ThrowsCouldNotInitiateConsumerSessionException_WhenConsumerCountryCodeIsEmpty()
        {
            //ARRANGE
            var orderResoureRequest = _consumerResourceRequestContainer.WithEmtptyConsumerCountryCode()
                .Build();
           
            //ASSERT
            await Assert.ThrowsAsync<CouldNotInitiateConsumerSessionException>(() => _sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest));
        }
        [Fact]
        public async Task InitializeConsumer_ReturnsNonEmptyOperationsCollection()
        {
            //ARRANGE
            var orderResoureRequest = _consumerResourceRequestContainer.WithTestValues()
                .Build();

            //ACT
            var orderResourceResponse = await _sut.Consumers.InitiateSession(orderResoureRequest.ConsumersRequest);

            //ASSERT
            Assert.NotNull(orderResourceResponse);
            Assert.NotNull(orderResourceResponse.Operations);
            Assert.NotEmpty(orderResourceResponse.Operations);
           
        }

        [Fact]
        public async Task GetShippingDetails_Returns_CorrectDetails()
        {
            //ARRANGE
                   
            var uri = "/psp/consumers/11d724b68625ea1149a60bc053c306affe6f38fe91d800d88f1109f6461f44d0/shipping-details";
            //ACT
            var shippingDetails = await _sut.Consumers.GetShippingDetails(uri);

            //ASSERT
            Assert.NotNull(shippingDetails);
            Assert.NotNull(shippingDetails.ShippingAddress);
            Assert.Equal("+46739000001", shippingDetails.Msisdn);
            Assert.Equal("leia.ahlstrom@payex.com", shippingDetails.Email);
            Assert.Equal("19792", shippingDetails.ShippingAddress.ZipCode);
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentException_IfUriIsWhitespace()
        {
            //ARRANGE
            string uri = " ";
            
            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumers.GetShippingDetails( uri));
        }

        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentException_IfUriIsNull()
        {
            //ARRANGE
            string uri = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumers.GetShippingDetails(uri));
        }

        [Fact]
        public async Task GetShippingDetails_ThrowsCouldNotGetShippingDetails_IfUriIsIncorrect()
        {
            //ARRANGE
            string uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<CouldNotGetShippingDetailsException>(() => _sut.Consumers.GetShippingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentException_IfUriIsWhitespace()
        {
            //ARRANGE
            string uri = " ";

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumers.GetBillingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentException_IfUriIsNull()
        {
            //ARRANGE
            string uri = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumers.GetBillingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsCouldNotGetBillingDetails_IfUriIsIncorrect()
        {
            //ARRANGE
            string uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<CouldNotGetBillingDetailsException>(() => _sut.Consumers.GetBillingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_Returns_CorrectDetails()
        {
            //ARRANGE
            var uri = "/psp/consumers/177a0e8cbc6777b6cddf72fbe3483c4cda6bef990c34c615376096c0fb607954/billing-details";
            
            //ACT
            var billingDetails = await _sut.Consumers.GetBillingDetails(uri);

            //ASSERT
            Assert.NotNull(billingDetails);
            Assert.NotNull(billingDetails.BillingAddress);
            Assert.Equal("+46739000001", billingDetails.Msisdn);
            Assert.Equal("leia.ahlstrom@payex.com", billingDetails.Email);
            Assert.Equal("19792", billingDetails.BillingAddress.ZipCode);
        }
    }
}
