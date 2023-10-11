using System.Reflection;

namespace SwedbankPay.Sdk;

/// <summary>
    /// Class for mapping API enum values to C# classes safely.
    /// </summary>
    /// <typeparam name="TEnum">The enum type you want to be safely cast.</typeparam>
    public abstract class TypeSafeEnum<TEnum> : IEquatable<TypeSafeEnum<TEnum>>
        where TEnum : TypeSafeEnum<TEnum>
    {
        private static readonly Lazy<Dictionary<string, TEnum?>> fromName =
            new(() => GetAllOptions().ToDictionary(item => item.Name)!);

        private static readonly Lazy<Dictionary<string, TEnum?>> fromNameIgnoreCase =
            new(() => GetAllOptions().ToDictionary(item => item.Name, StringComparer.OrdinalIgnoreCase)!);

        private static readonly Lazy<Dictionary<string, TEnum?>> fromValue =
            new(() =>
            {
                // multiple enums with same value are allowed but store only one per value
                var dictionary = new Dictionary<string, TEnum?>();
                foreach (var item in GetAllOptions())
                {
                    if (!dictionary.ContainsKey(item.Value))
                    {
                        dictionary.Add(item.Value, item);
                    }
                }

                return dictionary;
            });

        /// <summary>
        /// Instantiates a <see cref="TypeSafeEnum{TEnum}"/> with the provided parameters.
        /// </summary>
        /// <param name="name">The name of the value in C#.</param>
        /// <param name="value">The value of the value in API requests.</param>
        protected TypeSafeEnum(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets all internal values as a list.
        /// </summary>
        public static IReadOnlyCollection<TEnum?> List =>
            fromName.Value.Values
                .ToList()
                .AsReadOnly();

        /// <summary>
        /// The name of the enum value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The API value of the value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="other"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public virtual bool Equals(TypeSafeEnum<TEnum>? other)
        {
            // check if same instance
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // it's not same instance so 
            // check if it's not null and is same value
            if (other is null)
            {
                return false;
            }

            return Value.Equals(other.Value);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public override bool Equals(object? obj)
        {
            return obj is TypeSafeEnum<TEnum> other && Equals(other);
        }

        /// <summary>
        /// Maps to <typeparamref name="TEnum"/> from <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the enum value.</param>
        /// <param name="ignoreCase">Set if casing should be ignored.</param>
        /// <returns><typeparamref name="TEnum"/>.</returns>
        public static TEnum? FromName(string name, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument cannot be null or empty.", name);
            }

            if (ignoreCase)
            {
                return FromName(fromNameIgnoreCase.Value);
            }

            return FromName(fromName.Value);

            TEnum? FromName(Dictionary<string, TEnum?> dictionary)
            {
                if (!dictionary.TryGetValue(name, out var result))
                {
                    throw new KeyNotFoundException($"Key: {name} not found.");
                }

                return result;
            }
        }

        /// <summary>
        /// Maps to <typeparamref name="TEnum"/> from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value of the enum.</param>
        /// <returns><typeparamref name="TEnum"/>.</returns>
        public static TEnum? FromValue(string? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!fromValue.Value.TryGetValue(value, out var result))
            {
                var constructor = typeof(TEnum).GetConstructor(new Type[] { typeof(string), value.GetType() });
                if (constructor != null)
                {
                    var instance = constructor.Invoke(new object[] { value, value });
                    return (TEnum)instance;
                }
                throw new KeyNotFoundException($"Key: {value} not found.");
            }

            return result;
        }

        /// <summary>
        /// Maps to <typeparamref name="TEnum"/> from <paramref name="value"/>.
        /// Sets to default value if not possible
        /// </summary>
        /// <param name="value">The value of the enum.</param>
        /// <param name="defaultString">Default value if mapping is not possible.</param>
        /// <returns><typeparamref name="TEnum"/>.</returns>
        public static TEnum? FromValue(string? value, TEnum defaultString)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!fromValue.Value.TryGetValue(value, out var result))
            {
                return defaultString;
            }

            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Tries mapping to <typeparamref name="TEnum"/> from <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the enum.</param>
        /// <param name="result">The enum result.</param>
        /// <returns>true if successfull, false otherwise.</returns>
        public static bool TryFromName(string name, out TEnum? result)
        {
            return TryFromName(name, false, out result);
        }

        /// <summary>
        /// Tries mapping to <typeparamref name="TEnum"/> from <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the enum.</param>
        /// <param name="result">The enum result.</param>
        /// <param name="ignoreCase">Set if casing should be ignored.</param>
        /// <returns>true if successful, false otherwise.</returns>
        public static bool TryFromName(string name, bool ignoreCase, out TEnum? result)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (ignoreCase)
            {
                return fromNameIgnoreCase.Value.TryGetValue(name, out result);
            }

            return fromName.Value.TryGetValue(name, out result);
        }

        /// <summary>
        /// Will try to map from <paramref name="value"/> to a <typeparamref name="TEnum"/>.
        /// </summary>
        /// <param name="value">The value to map to <typeparamref name="TEnum"/>.</param>
        /// <param name="result">The result from mapping.</param>
        /// <returns>true if sucsessfull, false otherwise.</returns>
        public static bool TryFromValue(string? value, out TEnum? result)
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
            var enumTypes = Assembly.GetAssembly(baseType)?.GetTypes().Where(t => baseType.IsAssignableFrom(t));

            var options = new List<TEnum>();
            if (enumTypes != null)
            {
                foreach (var enumType in enumTypes)
                {
                    var typeEnumOptions = enumType.GetFieldsOfType<TEnum>();
                    options.AddRange(typeEnumOptions);
                }
            }

            return options.OrderBy(t => t.Name).ToList();
        }
    }