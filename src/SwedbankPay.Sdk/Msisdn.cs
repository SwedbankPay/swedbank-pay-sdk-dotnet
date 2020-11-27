using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Object to hold a consumers/payers <seealso cref="Msisdn"/> information.
    /// </summary>
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

        /// <summary>
        /// Method to validate a provided <seealso cref="string"/>.
        /// </summary>
        /// <param name="msisdn">The <seealso cref="string"/> to validate.</param>
        /// <returns>false if not valid, true otherwise.</returns>
        public static bool IsValidMsisdn(string msisdn)
        {
            if (string.IsNullOrWhiteSpace(msisdn))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}