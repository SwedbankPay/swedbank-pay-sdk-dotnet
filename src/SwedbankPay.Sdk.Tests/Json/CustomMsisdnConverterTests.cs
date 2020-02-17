using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwedbankPay.Sdk.Payments;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomMsisdnConverterTests
    {
        [Fact]
        public void CanDeSerialize_Msisdn()
        {
            //ARRANGE
            var jsonObject = new JObject { { "msisdn", "+46701234567" } };

            //ACT
            var result = JsonConvert.DeserializeObject<Msisdn>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal("+46701234567", result.ToString());
        }


        [Fact]
        public void CanSerialize_Msisdn()
        {
            var prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));

            //ACT
            var result = JsonConvert.SerializeObject(prefillInfo, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("Msisdn", StringComparison.InvariantCultureIgnoreCase, out var msisdn);

            //ASSERT
            Assert.Equal("+46701234567", msisdn);
        }
    }
}
