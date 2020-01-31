using System;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwedbankPay.Sdk.PaymentOrders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomDateTimeConverterTests
    {
        [Fact]
        public void CanConvert_DateTime()
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
                    CountryCode = new RegionInfo("NO")
                }
            };

            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator, JsonSerialization.JsonSerialization.Settings);
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