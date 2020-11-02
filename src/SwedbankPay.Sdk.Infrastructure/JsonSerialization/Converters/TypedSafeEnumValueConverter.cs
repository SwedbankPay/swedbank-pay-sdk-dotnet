using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    public class TypedSafeEnumValueConverter<TEnum, TValue> : JsonConverter<TEnum>
        where TEnum : TypeSafeEnum<TEnum, TValue>
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
                reader.GetString();
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
                TValue value;
                if (reader.TokenType == JsonTokenType.Number && typeof(TValue) != typeof(long) && typeof(TValue) != typeof(bool))
                    value = (TValue)Convert.ChangeType(reader.GetInt64(), typeof(TValue));
                else
                    value = (TValue)Enum.Parse(typeToConvert, reader.GetString());

                return TypeSafeEnum<TEnum, TValue>.FromValue(value);
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
            else if (value is null && options.IgnoreNullValues)
            {
                return;
            }
            else
            {
                writer.WriteStringValue(value.Value.ToString());
            }
        }
    }
}