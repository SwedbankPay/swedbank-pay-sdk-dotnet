using System.Globalization;
using System.Text.Json;

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
            var jsonObject = $"{{ \"region\": \"{regionInfoString}\"}}";

            //ACT
            var result = JsonSerializer.Deserialize<RegionInfo>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

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
            var dummy = new DummyRegionInfo
            {
                Region = new RegionInfo(regionInfoString)
            };

            //ACT
            var result = JsonSerializer.Serialize(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);

            var region = obj.RootElement.GetProperty("region").ToString();
            //ASSERT
            Assert.Equal(regionInfoString, region);
        }

        private class DummyRegionInfo
        {
            public RegionInfo Region { get; set; }
        }
    }
}