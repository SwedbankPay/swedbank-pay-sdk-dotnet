using System;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomRegionInfoConverterTests
    {
        [Theory]
        [InlineData("SE")]
        [InlineData("NO")]
        [InlineData("GB")]
        public void CanDeSerialize_RegionInfo(string regionInfoString)
        {
            //ARRANGE
            var jsonObject = new JObject { { "region", regionInfoString } };

            //ACT
            var result = JsonConvert.DeserializeObject<RegionInfo>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(regionInfoString, result.Name);
        }


        [Theory]
        [InlineData("SE")]
        [InlineData("NO")]
        [InlineData("GB")]
        public void CanSerialize_RegionInfo(string regionInfoString)
        {
            //ARRANGE
            var dummy = new
            {
                Region = new RegionInfo(regionInfoString)
            };

            //ACT
            var result = JsonConvert.SerializeObject(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);

            obj.TryGetValue("Region", StringComparison.InvariantCultureIgnoreCase, out var region);
            //ASSERT
            Assert.Equal(regionInfoString, region);
        }
    }
}