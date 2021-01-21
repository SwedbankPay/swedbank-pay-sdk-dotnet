using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Identifies a consumer with country and social security number.
    /// </summary>
    public class NationalIdentifier
    {
        /// <summary>
        /// Instantiates a <see cref="NationalIdentifier"/> with the provided parameters.
        /// </summary>
        /// <param name="countryCode">The payers country code.</param>
        /// <param name="socialSecurityNumber">The payers provided social security number.</param>
        public NationalIdentifier(CountryCode countryCode, string socialSecurityNumber)
        {
            CountryCode = countryCode ?? throw new ArgumentNullException(nameof(countryCode));
            SocialSecurityNumber = socialSecurityNumber ?? throw new ArgumentNullException(nameof(socialSecurityNumber));
        }

        /// <summary>
        ///     The country code, denoting origin for the issued social security number. Required if
        ///     nationalIdentifier.socialSecurityNumber is set.
        /// </summary>
        public CountryCode CountryCode { get; }

        /// <summary>
        ///     The social security number of the payer. Format: Norway DDMMYYXXXXX, Sweden: YYYYMMDDXXXX.
        /// </summary>
        public string SocialSecurityNumber { get; }
    }
}