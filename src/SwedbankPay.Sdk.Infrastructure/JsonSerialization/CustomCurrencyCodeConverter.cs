using System;
using System.Linq;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomCurrencyCodeConverter

    {
        private readonly Type[] types;


        public CustomCurrencyCodeConverter(params Type[] types)
        {
            this.types = types;
        }


        public CustomCurrencyCodeConverter()
        {
        }


        public bool CanRead => true;


        public bool CanConvert(Type objectType)
        {
            return this.types.Any(t => t == objectType);
        }


        //public object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        //{
        //    if (reader.TokenType == JsonToken.StartObject)
        //    {
        //        var jo = JObject.Load(reader);
        //        var currencyCodeString = jo.Values().FirstOrDefault()?.ToString();
        //        return new CurrencyCode(currencyCodeString);
        //    }

        //    return new CurrencyCode(reader.Value.ToString());
        //}


        //public void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    var t = JToken.FromObject(value);

        //    if (t.Type != JTokenType.Object)
        //        t.WriteTo(writer);
        //    else
        //        writer.WriteValue(value.ToString());
        //}
    }
}