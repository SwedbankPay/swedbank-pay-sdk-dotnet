namespace SwedbankPay.Sdk
{
    using Newtonsoft.Json;

    using System;

    public class TypedSafeEnumValueConverter<TEnum, TValue> : JsonConverter<TEnum> where TEnum : TypeSafeEnum<TEnum, TValue>
    {
        /// <summary>
        /// Can read
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Can write
        /// </summary>
        public override bool CanWrite => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="hasExistingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override TEnum ReadJson(JsonReader reader, Type objectType, TEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                TValue value;
                if (reader.TokenType == JsonToken.Integer && typeof(TValue) != typeof(long) && typeof(TValue) != typeof(bool))
                {
                    value = (TValue)Convert.ChangeType(reader.Value, typeof(TValue));
                }
                else
                {
                    value = (TValue)reader.Value;
                }

                return TypeSafeEnum<TEnum, TValue>.FromValue(value);
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException($"Error converting {reader.Value ?? "Null"} to {objectType.Name}.", ex);
            }
        }

        /// <summary>
        /// Write json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, TEnum value, JsonSerializer serializer)
        {
            if (value is null)
                writer.WriteNull();
            else
                writer.WriteValue(value.Value);
        }
    }

}