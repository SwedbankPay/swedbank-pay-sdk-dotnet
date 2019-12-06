namespace SwedbankPay.Sdk.JsonSerialization
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class CustomAmountConverter : JsonConverter

    {
        private readonly Type[] types;

        public CustomAmountConverter(params Type[] types)
        {
            this.types = types;
        }

        public CustomAmountConverter()
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
            try
            {
                var value = (long)reader.Value;
                return new Amount(value);
            }
            catch (Exception exception)
            {
                throw new JsonSerializationException($"Error converting {reader.Value ?? "Null"} to {objectType.Name}.", exception);
            }
        }

        public override bool CanRead => true;
        
        public override bool CanConvert(Type objectType)
        {
            return this.types.Any(t => t == objectType);
        }
    }
}