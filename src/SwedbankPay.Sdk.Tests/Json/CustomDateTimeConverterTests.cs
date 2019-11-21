namespace SwedbankPay.Sdk.Tests.Json
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.JsonSerialization;
    using SwedbankPay.Sdk.PaymentOrders;
    using Xunit;

    public class CustomDateTimeConverterTests
    {

        [Fact]
        public async Task CanConvert_DateTime()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator
            {
                PreOrderDate = new DateTime(2020, 1, 1),
                ShipIndicator = ShipIndicator.ShipToAnotherVerifiedAddressOnFileWithMerchant,
                DeliveryTimeFrameIndicator = DeliveryTimeFrameIndicator.TwoDayOrMoreShipping,
                DeliveryEmailAddress = new EmailAddress("test@test.com"),
                PreOrderPurchaseIndicator = PreOrderPurchaseIndicator.FutureAvailability,
                ReOrderPurchaseIndicator = ReOrderPurchaseIndicator.MerchandiseAvailable,
                PickUpAddress = new PickUpAddress
                {
                    CountryCode = CountryCode.NO
                }

                
            };

            var setting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new CustomEmailAddressConverter(typeof(EmailAddress)),
                    new TypedSafeEnumValueConverter<ShipIndicator, string>(),
                    new TypedSafeEnumValueConverter<DeliveryTimeFrameIndicator, string>(),
                    new TypedSafeEnumValueConverter<PreOrderPurchaseIndicator, string>(),
                    new TypedSafeEnumValueConverter<ReOrderPurchaseIndicator, string>(),
                },
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyyMMdd"
            };

            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator, setting);
            var obj = JObject.Parse(result);

            var dateTimeAsString = obj.GetValue("preOrderDate").ToString();
            var shipInd = obj.GetValue("shipIndicator").ToString();
            var delTimeFrameInd = obj.GetValue("deliveryTimeFrameIndicator").ToString();
            var preOrdPurchaseInd = obj.GetValue("preOrderPurchaseIndicator").ToString();
            var reOrdPurchaseInd = obj.GetValue("reOrderPurchaseIndicator").ToString();
            var email = obj.GetValue("deliveryEmailAddress").ToString();
            var countryCode = obj.GetValue("pickUpAddress")["countryCode"].ToString();
            
            //ASSERT
            Assert.Equal("20200101", dateTimeAsString);
            Assert.Equal("test@test.com", email);
            Assert.Equal("02", shipInd);
            Assert.Equal("02", preOrdPurchaseInd);
            Assert.Equal("01", reOrdPurchaseInd);
            Assert.Equal("04", delTimeFrameInd);
            Assert.Equal("NO", countryCode);
        }
    }
}