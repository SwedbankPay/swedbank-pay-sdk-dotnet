namespace SwedbankPay.Sdk.Tests.Json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SwedbankPay.Sdk.PaymentOrders;

    using System;

    using SwedbankPay.Sdk.JsonSerialization;

    using Xunit;

  

    public class CustomEmailAddressConverterTests
    {
        private string address = "email@example.com";

        [Fact]
        public void CanDeSerialize_EmailAddress()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("xX123xxaddress", this.address);

            //ACT
            var result = JsonConvert.DeserializeObject<EmailAddress>(jsonObject.ToString(), JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.address, result.ToString());
        }

        [Fact]
        public void CanSerialize_EmailAddress()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator { DeliveryEmailAddress = new EmailAddress(this.address) };

            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator, JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("DeliveryEmailAddress", StringComparison.InvariantCultureIgnoreCase, out var address);
            //ASSERT
            Assert.Equal(this.address, address.ToString());
        }
    }
}