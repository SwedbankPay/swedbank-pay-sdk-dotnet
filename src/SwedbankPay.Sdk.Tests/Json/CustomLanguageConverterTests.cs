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
            var jsonObject = $"{{ \"language\": \"{languageString}\" }}";

            //ACT
            var result = JsonSerializer.Deserialize<Language>(jsonObject, JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(languageString, result.ToString());
        }


        [Fact]
        public void CanSerialize_Language()
        {
            //ARRANGE
            var lang = new DummyLanguageClass
            {
                Language = new Language(languageString)
            };

            //ACT
            var result = JsonSerializer.Serialize(lang, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);

            var language = obj.RootElement.GetProperty("language").ToString();
            //ASSERT
            Assert.Equal(languageString, language);
        }

        private class DummyLanguageClass
        {
            public Language Language { get; set; }
        }
    }
}