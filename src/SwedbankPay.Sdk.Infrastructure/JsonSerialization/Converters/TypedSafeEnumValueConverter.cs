using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    internal class TypedSafeEnumValueConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : TypeSafeEnum<TEnum>
    {
        /// <summary>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                reader.Read();
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
                var valueToReturn = Read(ref reader, typeToConvert, options);
                reader.Read();
                return valueToReturn;
            }

            try
            {
                string value;
                if (reader.TokenType == JsonTokenType.Number )
                {
                    value = reader.GetInt64().ToString();
                }
                else
                {
                    value = reader.GetString();
                }

                return TypeSafeEnum<TEnum>.FromValue(value);
            }
            catch (Exception e)
            {
                throw new JsonException($"Error converting {reader.GetString() ?? "Null"} to {typeToConvert.Name}.", e);
            }
        }

        /// <summary>
        ///     Write json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            if (value is null && !options.IgnoreNullValues)
            {
                writer.WriteNullValue();
            }
            else if (value != null)
            {
                writer.WriteStringValue(value.Value.ToString());
            }
        }
    }
}