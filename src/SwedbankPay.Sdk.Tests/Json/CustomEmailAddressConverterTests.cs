using System;
using System.Text.Json;

using SwedbankPay.Sdk.PaymentOrders;

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

            var jsonObject = $"{{ {{ \"xX123xxaddress\", {this.address} }} }}";

            //ACT
            var result = JsonSerializer.Deserialize<EmailAddress>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

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
            var address = obj.RootElement.GetProperty("DeliveryEmailAddress");
            //ASSERT
            Assert.Equal(this.address, address.ToString());
        }
    }
}