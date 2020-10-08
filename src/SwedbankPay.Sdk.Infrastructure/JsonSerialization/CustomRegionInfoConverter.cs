using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomRegionInfoConverter : JsonConverter<RegionInfo>
    {
        public override RegionInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var regionInfoString = reader.GetString();

                if (string.IsNullOrEmpty(regionInfoString))
                    return null;
                return new RegionInfo(regionInfoString);
            }
            else if (reader.TokenType == JsonTokenType.Null)
                return null;
            throw new JsonException();
        }


        public override void Write(Utf8JsonWriter writer, RegionInfo value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(typeof(RegionInfo).Name);
            if(value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(value.Name);
        }
    }
}