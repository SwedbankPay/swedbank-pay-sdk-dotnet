using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwedbankPay.Sdk
{
    public abstract class TypeSafeEnum<TEnum, TValue> where TEnum : TypeSafeEnum<TEnum, TValue>
    {
        static readonly Lazy<Dictionary<string, TEnum>> _fromName =
            new Lazy<Dictionary<string, TEnum>>(() => GetAllOptions().ToDictionary(item => item.Name));

        static readonly Lazy<Dictionary<string, TEnum>> _fromNameIgnoreCase =
            new Lazy<Dictionary<string, TEnum>>(() => GetAllOptions().ToDictionary(item => item.Name, StringComparer.OrdinalIgnoreCase));

        static readonly Lazy<Dictionary<TValue, TEnum>> _fromValue =
            new Lazy<Dictionary<TValue, TEnum>>(() =>
            {
                // multiple enums with same value are allowed but store only one per value
                var dictionary = new Dictionary<TValue, TEnum>();
                foreach (var item in GetAllOptions())
                {
                    if (!dictionary.ContainsKey(item._value))
                        dictionary.Add(item._value, item);
                }
                return dictionary;
            });

        private static IEnumerable<TEnum> GetAllOptions()
        {
            Type baseType = typeof(TEnum);
            IEnumerable<Type> enumTypes = Assembly.GetAssembly(baseType).GetTypes().Where(t => baseType.IsAssignableFrom(t));

            List<TEnum> options = new List<TEnum>();
            foreach (Type enumType in enumTypes)
            {
                List<TEnum> typeEnumOptions = enumType.GetFieldsOfType<TEnum>();
                options.AddRange(typeEnumOptions);
            }

            return options.OrderBy(t => t.Name).ToList();
        }

        public static IReadOnlyCollection<TEnum> List =>
            _fromName.Value.Values
                .ToList()
                .AsReadOnly();

        private readonly string _name;
        private readonly TValue _value;

        public string Name =>
            _name;

        public TValue Value =>
            _value;

        protected TypeSafeEnum(string name, TValue value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _name = name;
            _value = value;
        }

        public Type GetValueType() =>
            typeof(TValue);

        public static TEnum FromName(string name, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Argument cannot be null or empty.", name);

            if (ignoreCase)
                return FromName(_fromNameIgnoreCase.Value);
            else
                return FromName(_fromName.Value);

            TEnum FromName(Dictionary<string, TEnum> dictionary)
            {
                if (!dictionary.TryGetValue(name, out var result))
                {
                    throw new KeyNotFoundException($"Key: {name} not found.");
                }
                return result;
            }
        }

        public static bool TryFromName(string name, out TEnum result) =>
            TryFromName(name, false, out result);

        public static bool TryFromName(string name, bool ignoreCase, out TEnum result)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (ignoreCase)
                return _fromNameIgnoreCase.Value.TryGetValue(name, out result);
            else
                return _fromName.Value.TryGetValue(name, out result);
        }

        public static TEnum FromValue(TValue value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!_fromValue.Value.TryGetValue(value, out var result))
            {
                throw new KeyNotFoundException($"Key: {value} not found.");
            }
            return result;
        }

        public static TEnum FromValue(TValue value, TEnum defaultValue)
        {
            if (value == null)

                throw new ArgumentNullException(nameof(value));

            if (!_fromValue.Value.TryGetValue(value, out var result))
            {
                return defaultValue;
            }
            return result;
        }

        public static bool TryFromValue(TValue value, out TEnum result)
        {
            if (value == null)
            {
                result = default;
                return false;
            }

            return _fromValue.Value.TryGetValue(value, out result);
        }

        public override string ToString() =>
            _name;

        public override int GetHashCode() =>
            _value.GetHashCode();

        //public override bool Equals(object obj) =>
        //    (obj is TypeSafeEnum<TEnum, TValue> other) && Equals(other);

        //public virtual bool Equals(TypeSafeEnum<TEnum, TValue> other)
        //{
        //    // check if same instance
        //    if (Object.ReferenceEquals(this, other))
        //        return true;

        //    // it's not same instance so 
        //    // check if it's not null and is same value
        //    if (other is null)
        //        return false;

        //    return _value.Equals(other._value);

        //}

        //public static bool operator ==(TypeSafeEnum<TEnum, TValue> left, TypeSafeEnum<TEnum, TValue> right)
        //{
        //    // Handle null on left side
        //    if (left is null)
        //        return right is null; // null == null = true

        //    // Equals handles null on right side
        //    return left.Equals(right);
        //}

        //public static bool operator !=(TypeSafeEnum<TEnum, TValue> left, TypeSafeEnum<TEnum, TValue> right) =>
        //    !(left == right);

        //public virtual int CompareTo(TypeSafeEnum<TEnum, TValue> other) =>
        //    _value.CompareTo(other._value);

        //public static bool operator <(TypeSafeEnum<TEnum, TValue> left, TypeSafeEnum<TEnum, TValue> right) =>
        //    left.CompareTo(right) < 0;

        //public static bool operator <=(TypeSafeEnum<TEnum, TValue> left, TypeSafeEnum<TEnum, TValue> right) =>
        //    left.CompareTo(right) <= 0;

        //public static bool operator >(TypeSafeEnum<TEnum, TValue> left, TypeSafeEnum<TEnum, TValue> right) =>
        //    left.CompareTo(right) > 0;

        //public static bool operator >=(TypeSafeEnum<TEnum, TValue> left, TypeSafeEnum<TEnum, TValue> right) =>
        //    left.CompareTo(right) >= 0;

        //public static implicit operator TValue(TypeSafeEnum<TEnum, TValue> indicatorEnum) =>
        //    indicatorEnum._value;

        //public static explicit operator TypeSafeEnum<TEnum, TValue>(TValue value) =>
        //    FromValue(value);
    }
}