using System;
using System.Globalization;

namespace SwedbankPay.Sdk
{
    public class Amount : IEquatable<Amount>, IComparable<Amount>, IComparable
    {
        private readonly decimal amount;

        public Amount(decimal decimalAmount)
        {
            amount = decimalAmount;

            // Use "Banker's Rounding" by default.
            const MidpointRounding roundingMode = MidpointRounding.ToEven;
            var roundedAmount = Math.Round(amount, 2, roundingMode);
            InLowestMonetaryUnit = (long)(roundedAmount * 100);
        }

        /// <summary>
        /// Gets the amount in a format suitable for api requests.
        /// </summary>
        public long InLowestMonetaryUnit { get; }

        /// <summary>
        /// Returns the original amount passed in the constructor.
        /// </summary>
        /// <param name="amount">The <seealso cref="Amount"/> you want converted.</param>
        public static implicit operator decimal(Amount amount)
        {
            return amount.amount;
        }

        /// <summary>
        /// Converts a <seealso cref="decimal"/> to a <seealso cref="Amount"/>
        /// </summary>
        /// <param name="amount">The <seealso cref="decimal"/> you want converted.</param>
        public static implicit operator Amount(decimal amount)
        {
            return new Amount(amount);
        }

        /// <summary>
        /// Converts a <seealso cref="int"/> to a <seealso cref="Amount"/>.
        /// </summary>
        /// <param name="amount">The <seealso cref="int"/> you want to convert.</param>
        public static implicit operator Amount(int amount)
        {
            return FromLowestMonetaryUnit(amount);
        }

        public static Amount operator +(Amount a, Amount b)
        {
            return new Amount(a.amount + b.amount);
        }

        public static Amount operator -(Amount a, Amount b)
        {
            return new Amount(a.amount - b.amount);
        }

        /// <summary>
        /// Converts a <seealso cref="int"/> to a <seealso cref="Amount"/>.
        /// </summary>
        /// <param name="amountInLowestMonetaryUnit">The amount.</param>
        /// <returns>A new <seealso cref="Amount"/> based on the <paramref name="amountInLowestMonetaryUnit"/>.</returns>
        public static Amount FromLowestMonetaryUnit(int amountInLowestMonetaryUnit)
        {
            var convertedAmount = (decimal)amountInLowestMonetaryUnit / 100;
            return new Amount(convertedAmount);
        }

        /// <summary>
        /// Converts a <seealso cref="long"/> to a <seealso cref="Amount"/>.
        /// </summary>
        /// <param name="amountInLowestMonetaryUnit">The amount.</param>
        /// <returns>A new <seealso cref="Amount"/> based on the <paramref name="amountInLowestMonetaryUnit"/>.</returns>
        public static Amount FromLowestMonetaryUnit(long amountInLowestMonetaryUnit)
        {
            var convertedAmount = (decimal)amountInLowestMonetaryUnit / 100;
            return new Amount(convertedAmount);
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (!(obj is Amount))
            {
                throw new ArgumentException($"Object must be of type {nameof(Amount)}");
            }

            return CompareTo((Amount)obj);
        }

        public int CompareTo(Amount other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (other is null)
            {
                return 1;
            }

            return amount.CompareTo(other.amount);
        }

        public bool Equals(Amount other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return amount == other.amount;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Amount)obj);
        }

        public override int GetHashCode()
        {
            return amount.GetHashCode();
        }

        public override string ToString()
        {
            return ToString("N2");
        }

        public string ToString(string format)
        {
            return amount.ToString(format, CultureInfo.InvariantCulture);
        }

        public static bool operator ==(Amount left, Amount right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Amount left, Amount right)
        {
            return !(left.InLowestMonetaryUnit == right.InLowestMonetaryUnit);
        }

        public static bool operator <(Amount left, Amount right)
        {
            return left is null ? right is object : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Amount left, Amount right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Amount left, Amount right)
        {
            return left is object && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Amount left, Amount right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}