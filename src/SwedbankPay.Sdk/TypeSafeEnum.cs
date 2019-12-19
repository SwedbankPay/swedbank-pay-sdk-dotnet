using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwedbankPay.Sdk
{
    public abstract class TypeSafeEnum<TEnum, TValue>
        where TEnum : TypeSafeEnum<TEnum, TValue>
    {
        private static readonly Lazy<Dictionary<string, TEnum>> fromName =
            new Lazy<Dictionary<string, TEnum>>(() => GetAllOptions().ToDictionary(item => item.Name));

        private static readonly Lazy<Dictionary<string, TEnum>> fromNameIgnoreCase =
            new Lazy<Dictionary<string, TEnum>>(() => GetAllOptions().ToDictionary(item => item.Name, StringComparer.OrdinalIgnoreCase));

        private static readonly Lazy<Dictionary<TValue, TEnum>> fromValue =
            new Lazy<Dictionary<TValue, TEnum>>(() =>
            {
                // multiple enums with same value are allowed but store only one per value
                var dictionary = new Dictionary<TValue, TEnum>();
                foreach (var item in GetAllOptions())
                    if (!dictionary.ContainsKey(item.value))
                        dictionary.Add(item.value, item);
                return dictionary;
            });

        private readonly TValue value;


        protected TypeSafeEnum(string name, TValue value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Name = name;
            this.value = value;
        }


        public static IReadOnlyCollection<TEnum> List =>
            fromName.Value.Values
                .ToList()
                .AsReadOnly();

        public string Name { get; }

        public TValue Value =>
            this.value;


        public override bool Equals(object obj)
        {
            return obj is TypeSafeEnum<TEnum, TValue> other && Equals(other);
        }


        public virtual bool Equals(TypeSafeEnum<TEnum, TValue> other)
        {
            // check if same instance
            if (ReferenceEquals(this, other))
                return true;

            // it's not same instance so 
            // check if it's not null and is same value
            if (other is null)
                return false;

            return this.value.Equals(other.value);
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


        public static TEnum FromValue(TValue value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!fromValue.Value.TryGetValue(value, out var result))
                throw new KeyNotFoundException($"Key: {value} not found.");
            return result;
        }


        public static TEnum FromValue(TValue value, TEnum defaultValue)
        {
            if (value == null)

                throw new ArgumentNullException(nameof(value));

            if (!fromValue.Value.TryGetValue(value, out var result))
                return defaultValue;
            return result;
        }


        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }


        public Type GetValueType()
        {
            return typeof(TValue);
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


        public static bool TryFromValue(TValue value, out TEnum result)
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