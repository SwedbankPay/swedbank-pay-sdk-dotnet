using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using SwedbankPay.Client.Exceptions;
using SwedbankPay.Client.Models.Response;
using SwedbankPay.Client.Tests.TestBuilders;
using Xunit;

namespace SwedbankPay.Client.Tests
{
    

    public class ConsumerResourceTests
    {
        private SwedbankPayClient _sut;

        private readonly ConsumerResourceRequestBuilder _consumerResourceRequestContainer = new ConsumerResourceRequestBuilder(); 
        public ConsumerResourceTests()
        {
            var swedbankPayOptions = new SwedbankPayOptions
            {
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com"),
                Token = "588431aa485611f8fce876731a1734182ca0c44fcad6b8d989e22f444104aadf",
                CallBackUrl = new Uri("https://payex.eu.ngrok.io/payment-callback?orderGroupId={orderGroupId}"),
                CompletePageUrl = new Uri("https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}"),
                CancelPageUrl = new Uri("https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}"),
                MerchantId = "91a4c8e0-72ac-425c-a687-856706f9e9a1"
            };

            _sut = new SwedbankPayClient(swedbankPayOptions);
        }

        [Fact]
        public async Task InitializeConsumer_ShouldReturn_TokenNotNull()
        {
            //ARRANGE
            var orderResoureRequest = _consumerResourceRequestContainer.WithTestValues()
                                                                                .Build();
            //ACT
            var orderResourceResponse = await _sut.Consumer.InitiateSession(orderResoureRequest);
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
            var orderResourceResponse = await _sut.Consumer.InitiateSession(orderResoureRequest);
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
            await Assert.ThrowsAsync<CouldNotInitiateConsumerSessionException>(() => _sut.Consumer.InitiateSession(orderResoureRequest));
        }
        [Fact]
        public async Task InitializeConsumer_ReturnsNonEmptyOperationsCollection()
        {
            //ARRANGE
            var orderResoureRequest = _consumerResourceRequestContainer.WithTestValues()
                .Build();

            //ACT
            var orderResourceResponse = await _sut.Consumer.InitiateSession(orderResoureRequest);

            //ASSERT
            Assert.NotNull(orderResourceResponse);
            Assert.NotNull(orderResourceResponse.Operations);
            Assert.NotEmpty(orderResourceResponse.Operations);
           
        }

        [Fact]
        public async Task GetShippingDetails_Returns_CorrectDetails()
        {
            //ARRANGE
            
            var expected = new ShippingDetails
            {
                Email = "leia.ahlstrom@payex.com",
                Msisdn = "+46739000001",
                ShippingAddress = new ShippingAddress
                {
                    Addressee = "Leia Ahlström",
                    City = "Bro",
                    CoAddress = "",
                    CountryCode = "SE",
                    StreetAddress = "Helgestavägen 9",
                    ZipCode = "19792"
                }
            };   
            var uri = "/psp/consumers/11d724b68625ea1149a60bc053c306affe6f38fe91d800d88f1109f6461f44d0/shipping-details";
            //ACT
            var shippingDetails = await _sut.Consumer.GetShippingDetails(uri);

            //ASSERT
            Assert.NotNull(shippingDetails);
            Assert.NotNull(shippingDetails.ShippingAddress);
            Assert.Equal(expected.Msisdn, shippingDetails.Msisdn);
            Assert.Equal(expected.Email, shippingDetails.Email);
            Assert.Equal(expected.ShippingAddress.ZipCode, expected.ShippingAddress.ZipCode);
        }


        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentException_IfUriIsWhitespace()
        {
            //ARRANGE
            string uri = " ";
            
            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumer.GetShippingDetails( uri));
        }

        [Fact]
        public async Task GetShippingDetails_ThrowsArgumentException_IfUriIsNull()
        {
            //ARRANGE
            string uri = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumer.GetShippingDetails(uri));
        }

        [Fact]
        public async Task GetShippingDetails_ThrowsCouldNotGetShippingDetails_IfUriIsIncorrect()
        {
            //ARRANGE
            string uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<CouldNotGetShippingDetailsException>(() => _sut.Consumer.GetShippingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentException_IfUriIsWhitespace()
        {
            //ARRANGE
            string uri = " ";

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumer.GetBillingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsArgumentException_IfUriIsNull()
        {
            //ARRANGE
            string uri = null;

            //ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.Consumer.GetBillingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_ThrowsCouldNotGetBillingDetails_IfUriIsIncorrect()
        {
            //ARRANGE
            string uri = "xxx";

            //ASSERT
            await Assert.ThrowsAsync<CouldNotGetBillingDetailsException>(() => _sut.Consumer.GetBillingDetails(uri));
        }

        [Fact]
        public async Task GetBillingDetails_Returns_CorrectDetails()
        {
            //ARRANGE
            
            var expected = new BillingDetails
            {
                Email = "leia.ahlstrom@payex.com",
                Msisdn = "+46739000001",
                BillingAddress = new BillingAddress
                {
                    Addressee = "Leia Ahlström",
                    City = "Bro",
                    CountryCode = "SE",
                    StreetAddress = "Helgestavägen 9",
                    ZipCode = "19792"
                }
            };
            var uri = "/psp/consumers/177a0e8cbc6777b6cddf72fbe3483c4cda6bef990c34c615376096c0fb607954/billing-details";
            
            //ACT
            var billingDetails = await _sut.Consumer.GetBillingDetails(uri);

            //ASSERT
            Assert.NotNull(billingDetails);
            Assert.NotNull(billingDetails.BillingAddress);
            Assert.Equal(expected.Msisdn, billingDetails.Msisdn);
            Assert.Equal(expected.Email, billingDetails.Email);
            Assert.Equal(expected.BillingAddress.ZipCode, expected.BillingAddress.ZipCode);
        }
    }
}
