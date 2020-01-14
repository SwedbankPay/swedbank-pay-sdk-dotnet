using System;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomCultureInfoConverterTests
    {
        private readonly string cultureInfoString = "sv-SE";


        [Fact]
        public void CanDeSerialize_CultureInfo()
        {
            //ARRANGE
            var jsonObject = new JObject { { "language", this.cultureInfoString } };

            //ACT
            var result = JsonConvert.DeserializeObject<CultureInfo>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.cultureInfoString, result.Name);
        }


        [Fact]
        public void CanSerialize_CultureInfo()
        {
            //ARRANGE
            var dummy = new
            {
                Language = new CultureInfo(this.cultureInfoString)
            };

            //ACT
            var result = JsonConvert.SerializeObject(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);

            obj.TryGetValue("Language", StringComparison.InvariantCultureIgnoreCase, out var language);
            //ASSERT
            Assert.Equal(this.cultureInfoString, language);
        }
    }
}