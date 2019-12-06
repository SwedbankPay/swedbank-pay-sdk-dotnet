using System;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class Amount
    {
        public long Value { get; }
        [JsonConstructor]
        private Amount(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Negative amount value is not allowed.");
            }
            this.Value = decimal.ToInt32(value);
        }
        
        internal Amount(long value)
        {
            this.Value = value;
        }

        public static decimal ToDecimal(Amount amount)
        {
            return (decimal) amount.Value / 100;
        }
        public static Amount FromDecimal(decimal amount)
        {
            return new Amount(amount * 100);
        }


        public static Amount FromInt(long amount)
        {
            return new Amount(amount * 100);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}