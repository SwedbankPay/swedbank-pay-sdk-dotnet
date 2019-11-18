using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SwedbankPay.Sdk.PaymentOrders;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomEmailAddressJsonTests
    {
        private string _address = "email@example.com";

        [Fact]
        public void CanDeSerialize_EmailAddress()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("xX123xxaddress", _address);
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomEmailAddressConverter(typeof(EmailAddress)));
            
            //ACT
            EmailAddress result = JsonConvert.DeserializeObject<EmailAddress>(jsonObject.ToString(), settings);

            //ASSERT
            Assert.Equal(_address, result.Value);
        }

        [Fact]
        public void CanSerialize_EmailAddress()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator();
            riskIndicator.DeliveryEmailAddress = new EmailAddress(_address);
            
            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator);
            var obj = JObject.Parse(result);
            obj.TryGetValue("DeliveryEmailAddress", StringComparison.InvariantCultureIgnoreCase, out var address);
            //ASSERT
            Assert.Equal(_address, address);
        }
    }
}