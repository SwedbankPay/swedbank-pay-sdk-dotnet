using System;
using System.Globalization;

namespace SwedbankPay.Sdk.Common
{
    public class Amount : IEquatable<Amount>, IComparable<Amount>, IComparable
    {
        private readonly decimal amount;

        public Amount(decimal amount)
        {
            this.amount = amount;

            // Use "Banker's Rounding" by default.
            const MidpointRounding roundingMode = MidpointRounding.ToEven;
            var roundedAmount = Math.Round(amount, 2, roundingMode);
            InLowestMonetaryUnit = (int)(roundedAmount * 100);
        }

        public int InLowestMonetaryUnit { get; }

        public static implicit operator decimal(Amount amount)
        {
            return amount.amount;
        }

        public static implicit operator Amount(decimal amount)
        {
            return new Amount(amount);
        }

        public static Amount operator +(Amount a, Amount b)
        {
            return new Amount(a.amount + b.amount);
        }

        public static Amount operator -(Amount a, Amount b)
        {
            return new Amount(a.amount - b.amount);
        }

        public static Amount FromLowestMonetaryUnit(int amountInLowestMonetaryUnit)
        {
            var amount = (decimal)amountInLowestMonetaryUnit / 100;
            return new Amount(amount);
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            if (!(obj is Amount))
                throw new ArgumentException($"Object must be of type {nameof(Amount)}");

            return CompareTo((Amount)obj);
        }

        public int CompareTo(Amount other)
        {
            if (ReferenceEquals(this, other))
                return 0;

            if (other is null)
                return 1;

            return amount.CompareTo(other.amount);
        }

        public bool Equals(Amount other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return amount == other.amount;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Amount)obj);
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
    }
}