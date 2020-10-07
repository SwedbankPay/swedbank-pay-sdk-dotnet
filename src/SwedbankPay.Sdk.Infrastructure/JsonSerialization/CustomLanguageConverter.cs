using System;
using System.Linq;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomLanguageConverter
    {
        public bool CanConvert(Type objectType)
        {
            return objectType == typeof(Language);
        }


        //public object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        //{
        //    if (reader.TokenType == JsonToken.String)
        //        return new Language((string)reader.Value);
        //    if (reader.TokenType == JsonToken.StartObject)
        //    {
        //        var jo = JObject.Load(reader);
        //        var language = jo.Values().FirstOrDefault()?.ToString();
        //        return language != null ? new Language(language) : null;
        //    }

        //    if (reader.TokenType == JsonToken.Null)
        //        return null;

        //    throw new InvalidOperationException(
        //        "Unhandled case for CustomLanguageConverter. Check to see if this converter has been applied to the wrong serialization type.");
        //}


        //public void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    if (null == value)
        //    {
        //        writer.WriteNull();
        //        return;
        //    }

        //    if (value is Language language)
        //    {
        //        writer.WriteValue(language.ToString());
        //        return;
        //    }

        //    throw new InvalidOperationException(
        //        "Unhandled case for CustomLanguageConverter. Check to see if this converter has been applied to the wrong serialization type.");
        //}
    }
}