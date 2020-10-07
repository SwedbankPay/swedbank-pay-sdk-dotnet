using System;
using System.Text.Json;

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
            var jsonObject = $"{{ \"language\", #{this.languageString} }}";

            //ACT
            var result = JsonSerializer.Deserialize<Language>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.languageString, result.ToString());
        }


        [Fact]
        public void CanSerialize_Language()
        {
            //ARRANGE
            var lang = new Language(this.languageString);
            var dummy = $"{{ \"Language\" : ${lang} }}";

            //ACT
            var result = JsonSerializer.Serialize(dummy, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);

            var language = obj.RootElement.GetProperty("Language").ToString();
            //ASSERT
            Assert.Equal(this.languageString, language);
        }
    }
}