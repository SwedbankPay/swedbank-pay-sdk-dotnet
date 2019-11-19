namespace SwedbankPay.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SwedbankPay.Sdk.PaymentOrders;

    public class CustomEmailAddressConverter: JsonConverter 

    {
        private readonly Type[] _types;

        public CustomEmailAddressConverter(params Type[] types)
        {
            _types = types;
        }

        public CustomEmailAddressConverter()
        {
            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                var o = (JObject)t;
                var propertyName = o.Properties().Select(p => p.Name).FirstOrDefault();
                var propertyValue = o.Root.Value<string>(propertyName);
                writer.WriteValue(propertyValue);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var addressString = jo.Values().FirstOrDefault()?.ToString(); 
            var address = new EmailAddress(addressString);
            return address;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }
}