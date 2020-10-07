using System;
using System.Linq;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomAmountConverter

    {
        private readonly Type[] types;


        public CustomAmountConverter(params Type[] types)
        {
            this.types = types;
        }


        public CustomAmountConverter()
        {
        }


        public bool CanRead => true;


        public bool CanConvert(Type objectType)
        {
            return this.types.Any(t => t == objectType);
        }


        //public object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        //{
        //    try
        //    {
        //        long value;
        //        if (reader.Value == null)
        //        {
        //            var jo = JObject.Load(reader);

        //            value = (long)jo.First.Values().FirstOrDefault();
        //        }
        //        else
        //        {
        //            value = (long)reader.Value;
        //        }

        //        return new Amount(value);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new JsonSerializationException($"Error converting {reader.Value ?? "Null"} to {objectType.Name}.", exception);
        //    }
        //}


        //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    var t = JToken.FromObject(value);

        //    if (t.Type != JTokenType.Object)
        //        t.WriteTo(writer);
        //    else
        //        writer.WriteValue(value.ToString());
        //}
    }
}