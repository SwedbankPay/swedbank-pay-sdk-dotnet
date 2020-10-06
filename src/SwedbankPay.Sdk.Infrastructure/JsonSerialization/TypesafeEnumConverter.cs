using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwedbankPay.Sdk.JsonSerialization
{
    //Original code found here: https://gist.github.com/gubenkoved/999eb73e227b7063a67a50401578c3a7
    public class TypesafeEnumConverter : JsonConverter
    {
        [ThreadStatic]
        private Dictionary<Type, Dictionary<string, object>> _fromValueMap; // string representation to Enum value map

        [ThreadStatic]
        private Dictionary<Type, Dictionary<object, string>> _toValueMap; // Enum value to string map

        public string UnknownValue { get; set; } = "Unknown";

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum && !objectType.IsDefined(typeof(FlagsAttribute));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            InitMap(objectType);

            if (reader.TokenType == JsonToken.String)
            {
                var enumText = reader.Value.ToString();

                var val = FromValue(objectType, enumText);

                if (val != null)
                    return val;
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                var enumVal = Convert.ToInt32(reader.Value);
                var values = (int[])Enum.GetValues(objectType);
                if (values.Contains(enumVal))
                {
                    return Enum.Parse(objectType, enumVal.ToString());
                }
            }

            var names = Enum.GetNames(objectType);

            var unknownName = names
                .Where(n => string.Equals(n, UnknownValue, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (unknownName == null)
            {
                throw new JsonSerializationException($"Unable to parse '{reader.Value}' to enum {objectType}. Consider adding Unknown as fail-back value.");
            }

            return Enum.Parse(objectType, unknownName);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type enumType = value.GetType();

            InitMap(enumType);

            var val = ToValue(enumType, value);

            writer.WriteValue(val);
        }

        #region Private methods
        private void InitMap(Type enumType)
        {
            if (this._fromValueMap == null)
                this._fromValueMap = new Dictionary<Type, Dictionary<string, object>>();

            if (this._toValueMap == null)
                this._toValueMap = new Dictionary<Type, Dictionary<object, string>>();

            if (this._fromValueMap.ContainsKey(enumType))
                return; // already initialized

            var fromMap = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            var toMap = new Dictionary<object, string>();

            FieldInfo[] fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                var name = field.Name;
                var enumValue = Enum.Parse(enumType, name);

                toMap[enumValue] = name;
                fromMap[name] = enumValue;
            }

            this._fromValueMap[enumType] = fromMap;
            this._toValueMap[enumType] = toMap;
        }

        private string ToValue(Type enumType, object obj)
        {
            Dictionary<object, string> map = this._toValueMap[enumType];

            return map[obj];
        }

        private object FromValue(Type enumType, string value)
        {
            Dictionary<string, object> map = this._fromValueMap[enumType];

            if (!map.ContainsKey(value))
                return null;

            return map[value];
        }
        #endregion
    }
}