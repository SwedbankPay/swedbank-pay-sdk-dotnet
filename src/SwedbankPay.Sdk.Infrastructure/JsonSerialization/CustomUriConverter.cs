using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomUriConverter : JsonConverter<Uri>
    {
        public override Uri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
                return new Uri(reader.GetString(), UriKind.RelativeOrAbsolute);
            if(reader.TokenType == JsonTokenType.StartObject)
            {
                if (reader.Read())
                    return this.Read(ref reader, typeToConvert, options);
            }
            throw new JsonException();
        }


        public override void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(typeof(Uri).Name);
            if(value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(value.OriginalString);
        }
    }
}