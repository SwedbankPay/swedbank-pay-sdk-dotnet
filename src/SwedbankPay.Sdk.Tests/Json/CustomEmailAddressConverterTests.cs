using SwedbankPay.Sdk.PaymentOrders;
using System.Text.Json;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomEmailAddressConverterTests
    {
        private readonly string address = "email@example.com";


        [Fact]
        public void CanDeSerialize_EmailAddress()
        {
            //ARRANGE

            var jsonObject = $"{{\"xX123xxaddress\": \"{this.address}\"}}";

            //ACT
            var result = JsonSerializer.Deserialize<EmailAddress>(jsonObject, JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.address, result.ToString());
        }


        [Fact]
        public void CanSerialize_EmailAddress()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator { DeliveryEmailAddress = new EmailAddress(this.address) };

            //ACT
            var result = JsonSerializer.Serialize(riskIndicator, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);
            var devliveryEmailAddress = obj.RootElement.GetProperty("deliveryEmailAddress");
            //ASSERT
            Assert.Equal(this.address, devliveryEmailAddress.ToString());
        }
    }
}