using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Globalization;
using System.Linq;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomCultureInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CultureInfo);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return new CultureInfo((string)reader.Value);
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jo = JObject.Load(reader);
                var language = jo.Values().FirstOrDefault()?.ToString();
                return language != null ? new CultureInfo(language) : null;
            }

            if (reader.TokenType == JsonToken.Null)
                return null;

            throw new InvalidOperationException(
                "Unhandled case for CustomCultureInfoConverter. Check to see if this converter has been applied to the wrong serialization type.");
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (null == value)
            {
                writer.WriteNull();
                return;
            }

            if (value is CultureInfo cultureInfo)
            {
                writer.WriteValue(cultureInfo.Name);
                return;
            }

            throw new InvalidOperationException(
                "Unhandled case for CustomCultureInfoConverter. Check to see if this converter has been applied to the wrong serialization type.");
        }
    }
}