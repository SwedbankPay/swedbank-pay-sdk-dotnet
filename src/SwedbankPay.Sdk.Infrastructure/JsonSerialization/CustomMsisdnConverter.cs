using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomMsisdnConverter : JsonConverter<Msisdn>
    {
        public override Msisdn Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var msisdnString = reader.GetString();
            return new Msisdn(msisdnString);
        }
        public override void Write(Utf8JsonWriter writer, Msisdn value, JsonSerializerOptions options)
        {
            writer.WriteString(typeof(Msisdn).Name, value.ToString());
        }
    }
}