using System;

namespace SwedbankPay.Sdk
{
    public class Msisdn
    {
        /// <summary>
        /// Creates a new <seealso cref="Msisdn"/>
        /// </summary>
        /// <param name="msisdn">The payers MSISDN.</param>
        public Msisdn(string msisdn)
        {
            if (!IsValidMsisdn(msisdn))
            {
                throw new ArgumentException($"Invalid msisdn: {msisdn}", nameof(msisdn));
            }

            Value = msisdn;
        }


        private string Value { get; }


        public static bool IsValidMsisdn(string msisdn)
        {
            if (string.IsNullOrWhiteSpace(msisdn))
            {
                return false;
            }

            return true;
        }


        public override string ToString()
        {
            return Value;
        }
    }
}