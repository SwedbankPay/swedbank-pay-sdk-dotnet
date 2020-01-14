using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Globalization;
using System.Linq;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomRegionInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RegionInfo);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return new RegionInfo((string)reader.Value);
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jo = JObject.Load(reader);
                var region = jo.Values().FirstOrDefault()?.ToString();
                return region != null ? new RegionInfo(region) : null;
            }

            if (reader.TokenType == JsonToken.Null)
                return null;

            throw new InvalidOperationException(
                "Unhandled case for CustomRegionInfoConverter. Check to see if this converter has been applied to the wrong serialization type.");
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (null == value)
            {
                writer.WriteNull();
                return;
            }

            if (value is RegionInfo regionInfo)
            {
                writer.WriteValue(regionInfo.Name);
                return;
            }

            throw new InvalidOperationException(
                "Unhandled case for CustomRegionInfoConverter. Check to see if this converter has been applied to the wrong serialization type.");
        }
    }
}