using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomCurrencyCodeConverter : JsonConverter<CurrencyCode>
    {
        public override CurrencyCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var currencyCodeString = reader.GetString();
            return new CurrencyCode(currencyCodeString);
        }


        public override void Write(Utf8JsonWriter writer, CurrencyCode value, JsonSerializerOptions options)
        {
            writer.WriteString(typeof(CurrencyCode).Name, value.ToString());
        }
    }
}