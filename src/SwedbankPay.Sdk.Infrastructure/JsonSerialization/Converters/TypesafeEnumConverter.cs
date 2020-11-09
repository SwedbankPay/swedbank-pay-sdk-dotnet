using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    //Original code found here: https://gist.github.com/gubenkoved/999eb73e227b7063a67a50401578c3a7
    public class TypesafeEnumConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : Enum
    {
        public string UnknownValue { get; } = "Unknown";

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                reader.Read();
            }
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
                var result =  Read(ref reader, typeToConvert, options);
                // Reads the end object.
                reader.Read();
                return result;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var enumText = reader.GetString();

                if (Enum.TryParse(typeToConvert, enumText, out var val))
                {
                    return (TEnum)val;
                }
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                var enumVal = reader.GetInt32();
                var values = (int[])Enum.GetValues(typeToConvert);
                if (values.Contains(enumVal))
                {
                    return (TEnum)Enum.Parse(typeToConvert, enumVal.ToString());
                }
            }

            var names = Enum.GetNames(typeToConvert);

            var unknownName = names
                .Where(n => string.Equals(n, UnknownValue, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (unknownName == null)
            {
                throw new JsonException($"Unable to parse '{reader.GetString()}' to enum {typeToConvert}. Consider adding Unknown as fail-back value.");
            }

            return (TEnum)Enum.Parse(typeToConvert, unknownName);
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
