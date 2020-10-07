using System;
using System.Linq;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomUriConverter
    {
        public bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }


        //public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        //{
        //    if (reader.TokenType == JsonToken.String)
        //        return new Uri((string)reader.Value, UriKind.RelativeOrAbsolute);
        //    if (reader.TokenType == JsonToken.StartObject)
        //    {
        //        var jo = JObject.Load(reader);
        //        var uri = jo.Values().FirstOrDefault()?.ToString();
        //        return uri != null ? new Uri(uri, UriKind.RelativeOrAbsolute) : null;
        //    }

        //    if (reader.TokenType == JsonToken.Null)
        //        return null;

        //    throw new InvalidOperationException(
        //        "Unhandled case for CustomUriConverter. Check to see if this converter has been applied to the wrong serialization type.");
        //}


        //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    if (null == value)
        //    {
        //        writer.WriteNull();
        //        return;
        //    }

        //    if (value is Uri uri)
        //    {
        //        writer.WriteValue(uri.OriginalString);
        //        return;
        //    }

        //    throw new InvalidOperationException(
        //        "Unhandled case for CustomUriConverter. Check to see if this converter has been applied to the wrong serialization type.");
        //}
    }
}