using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwedbankPay.Sdk
{
    public abstract class TypeSafeEnum<TEnum> : IEquatable<TypeSafeEnum<TEnum>>
        where TEnum : TypeSafeEnum<TEnum>
    {
        private static readonly Lazy<Dictionary<string, TEnum>> fromName =
            new Lazy<Dictionary<string, TEnum>>(() => GetAllOptions().ToDictionary(item => item.Name));

        private static readonly Lazy<Dictionary<string, TEnum>> fromNameIgnoreCase =
            new Lazy<Dictionary<string, TEnum>>(() => GetAllOptions().ToDictionary(item => item.Name, StringComparer.OrdinalIgnoreCase));

        private static readonly Lazy<Dictionary<string, TEnum>> fromValue =
            new Lazy<Dictionary<string, TEnum>>(() =>
            {
                // multiple enums with same value are allowed but store only one per value
                var dictionary = new Dictionary<string, TEnum>();
                foreach (var item in GetAllOptions())
                    if (!dictionary.ContainsKey(item.Value))
                        dictionary.Add(item.Value, item);
                return dictionary;
            });

        protected TypeSafeEnum(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Name = name;
            Value = value;
        }


        public static IReadOnlyCollection<TEnum> List =>
            fromName.Value.Values
                .ToList()
                .AsReadOnly();

        public string Name { get; }

        public string Value { get; }


        public virtual bool Equals(TypeSafeEnum<TEnum> other)
        {
            // check if same instance
            if (ReferenceEquals(this, other))
                return true;

            // it's not same instance so 
            // check if it's not null and is same value
            if (other is null)
                return false;

            return Value.Equals(other.Value);
        }


        public override bool Equals(object obj)
        {
            return obj is TypeSafeEnum<TEnum> other && Equals(other);
        }


        public static TEnum FromName(string name, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Argument cannot be null or empty.", name);

            if (ignoreCase)
                return FromName(fromNameIgnoreCase.Value);
            return FromName(fromName.Value);

            TEnum FromName(Dictionary<string, TEnum> dictionary)
            {
                if (!dictionary.TryGetValue(name, out var result))
                    throw new KeyNotFoundException($"Key: {name} not found.");
                return result;
            }
        }


        public static TEnum FromValue(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!fromValue.Value.TryGetValue(value, out var result))
            {
                var constructor = typeof(TEnum).GetConstructor(new Type[] { typeof(string), value.GetType() });
                if (constructor != null)
                {
                    var instance = constructor.Invoke(new object[] { value.ToString(), value });
                    return (TEnum)instance;
                }
                throw new KeyNotFoundException($"Key: {value} not found.");
            }

            return result;
        }


        public static TEnum FromValue(string value, TEnum defaulstring)
        {
            if (value == null)

                throw new ArgumentNullException(nameof(value));

            if (!fromValue.Value.TryGetValue(value, out var result))
                return defaulstring;
            return result;
        }


        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }


        public Type GestringType()
        {
            return typeof(string);
        }


        public override string ToString()
        {
            return Name;
        }


        public static bool TryFromName(string name, out TEnum result)
        {
            return TryFromName(name, false, out result);
        }


        public static bool TryFromName(string name, bool ignoreCase, out TEnum result)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (ignoreCase)
                return fromNameIgnoreCase.Value.TryGetValue(name, out result);
            return fromName.Value.TryGetValue(name, out result);
        }


        public static bool TryFromValue(string value, out TEnum result)
        {
            if (value == null)
            {
                result = default;
                return false;
            }

            return fromValue.Value.TryGetValue(value, out result);
        }


        private static IEnumerable<TEnum> GetAllOptions()
        {
            var baseType = typeof(TEnum);
            var enumTypes = Assembly.GetAssembly(baseType).GetTypes().Where(t => baseType.IsAssignableFrom(t));

            var options = new List<TEnum>();
            foreach (var enumType in enumTypes)
            {
                var typeEnumOptions = enumType.GetFieldsOfType<TEnum>();
                options.AddRange(typeEnumOptions);
            }

            return options.OrderBy(t => t.Name).ToList();
        }
    }
}