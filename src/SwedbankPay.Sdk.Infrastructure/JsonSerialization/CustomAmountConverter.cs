using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomAmountConverter: JsonConverter<Amount>
    {
        public override Amount Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(!reader.TryGetInt64(out var amountValue))
            {
                return new Amount(amountValue);
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Amount value, JsonSerializerOptions options)
        {
            writer.WriteNumber(typeof(Amount).Name, value.Value);
        }
    }
}