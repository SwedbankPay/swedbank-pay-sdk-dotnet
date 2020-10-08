using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomLanguageConverter : JsonConverter<Language>
    {
        public override Language Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var languageString = reader.GetString();
            return new Language(languageString);
        }


        public override void Write(Utf8JsonWriter writer, Language value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(typeof(Language).Name);
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStringValue(value.ToString());
        }
    }
}