namespace SwedbankPay.Sdk.Tests.Json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SwedbankPay.Sdk.PaymentOrders;

    using System;

    using SwedbankPay.Sdk.JsonSerialization;

    using Xunit;

    public class CustomEmailAddressJsonTests
    {
        private string address = "email@example.com";

        [Fact]
        public void CanDeSerialize_EmailAddress()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("xX123xxaddress", this.address);
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomEmailAddressConverter(typeof(EmailAddress)));

            //ACT
            var result = JsonConvert.DeserializeObject<EmailAddress>(jsonObject.ToString(), settings);

            //ASSERT
            Assert.Equal(this.address, result.ToString());
        }

        [Fact]
        public void CanSerialize_EmailAddress()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator { DeliveryEmailAddress = new EmailAddress(this.address) };

            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator);
            var obj = JObject.Parse(result);
            obj.TryGetValue("DeliveryEmailAddress", StringComparison.InvariantCultureIgnoreCase, out var address);
            //ASSERT
            Assert.Equal(this.address, address.ToString());
        }
    }
}