namespace SwedbankPay.Sdk.JsonSerialization
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    using SwedbankPay.Sdk.Payments;

    public class CustomCurrencyCodeConverter : JsonConverter

    {
        private readonly Type[] types;

        public CustomCurrencyCodeConverter(params Type[] types)
        {
            this.types = types;
        }

        public CustomCurrencyCodeConverter()
        {

        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                writer.WriteValue(value.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jo = JObject.Load(reader);
                var currencyCodeString = jo.Values().FirstOrDefault()?.ToString();
                return new CurrencyCode(currencyCodeString); 
            }

            return new CurrencyCode(reader.Value.ToString());
        }

        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return this.types.Any(t => t == objectType);
        }
    }
}