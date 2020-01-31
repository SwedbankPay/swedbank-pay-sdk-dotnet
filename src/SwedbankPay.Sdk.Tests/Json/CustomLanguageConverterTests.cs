using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomLanguageConverterTests
    {
        private readonly string languageString = "sv-SE";


        [Fact]
        public void CanDeSerialize_Language()
        {
            //ARRANGE
            var jsonObject = new JObject { { "language", languageString } };

            //ACT
            var result = JsonConvert.DeserializeObject<Language>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(languageString, result.ToString());
        }


        [Fact]
        public void CanSerialize_Language()
        {
            //ARRANGE
            var dummy = new
            {
                Language = new Language(languageString)
            };

            //ACT
            var result = JsonConvert.SerializeObject(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);

            obj.TryGetValue("Language", StringComparison.InvariantCultureIgnoreCase, out var language);
            //ASSERT
            Assert.Equal(languageString, language);
        }
    }
}