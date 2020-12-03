using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    internal class CustomRegionInfoConverter : JsonConverter<RegionInfo>
    {
        public override RegionInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                reader.GetString();
                reader.Read();
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                if (reader.Read())
                {
                    var uri = Read(ref reader, typeToConvert, options);
                    // Reads the EndObject
                    reader.Read();
                    return uri;
                }
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var regionInfoString = reader.GetString();

                if (string.IsNullOrEmpty(regionInfoString))
                {
                    return null;
                }

                return new RegionInfo(regionInfoString);
            }

            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            throw new JsonException();
        }


        public override void Write(Utf8JsonWriter writer, RegionInfo value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(value.Name);
        }
    }
}