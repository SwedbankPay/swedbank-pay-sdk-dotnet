using System;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomEmailAddressConverter : JsonConverter

    {
        private readonly Type[] types;


        public CustomEmailAddressConverter(params Type[] types)
        {
            this.types = types;
        }


        public CustomEmailAddressConverter()
        {
        }


        public override bool CanRead => true;


        public override bool CanConvert(Type objectType)
        {
            return this.types.Any(t => t == objectType);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jo = JObject.Load(reader);
                var addressString = jo.Values().FirstOrDefault()?.ToString();
                return new EmailAddress(addressString);
            }

            return new EmailAddress(reader.Value.ToString());
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
                t.WriteTo(writer);
            else
                writer.WriteValue(value.ToString());
        }
    }
}