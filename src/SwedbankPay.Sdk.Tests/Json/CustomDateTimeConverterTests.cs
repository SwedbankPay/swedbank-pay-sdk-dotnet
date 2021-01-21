using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Globalization;
using System.Text.Json;
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
                    CountryCode = new CountryCode("NO")
                }
            };
            var dto = new RiskIndicatorDto(riskIndicator);

            //ACT
            var result = JsonSerializer.Serialize(dto, JsonSerialization.JsonSerialization.Settings);
            using JsonDocument doc = JsonDocument.Parse(result);
            var dateTimeAsString = doc.RootElement.GetProperty("preOrderDate").ToString();
            var shipInd = doc.RootElement.GetProperty("shipIndicator").ToString();
            var delTimeFrameInd = doc.RootElement.GetProperty("deliveryTimeFrameIndicator").ToString();
            var preOrdPurchaseInd = doc.RootElement.GetProperty("preOrderPurchaseIndicator").ToString();
            var reOrdPurchaseInd = doc.RootElement.GetProperty("reOrderPurchaseIndicator").ToString();
            var email = doc.RootElement.GetProperty("deliveryEmailAddress").ToString();
            var countryCode = doc.RootElement.GetProperty("pickUpAddress").GetProperty("countryCode").ToString();

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