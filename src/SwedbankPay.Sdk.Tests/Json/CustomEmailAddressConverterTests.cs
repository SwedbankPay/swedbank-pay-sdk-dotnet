using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            var jsonObject = new JObject
            {
                { "xX123xxaddress", this.address }
            };

            //ACT
            var result = JsonConvert.DeserializeObject<EmailAddress>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.address, result.ToString());
        }


        [Fact]
        public void CanSerialize_EmailAddress()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator { DeliveryEmailAddress = new EmailAddress(this.address) };

            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("DeliveryEmailAddress", StringComparison.InvariantCultureIgnoreCase, out var address);
            //ASSERT
            Assert.Equal(this.address, address.ToString());
        }
    }
}