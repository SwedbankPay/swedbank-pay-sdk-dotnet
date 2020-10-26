using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class NationalIdentifier
    {
        public NationalIdentifier(RegionInfo countryCode, string socialSecurityNumber)
        {
            CountryCode = countryCode ?? throw new ArgumentNullException(nameof(countryCode));
            SocialSecurityNumber = socialSecurityNumber ?? throw new ArgumentNullException(nameof(socialSecurityNumber));
        }

        /// <summary>
        ///     The country code, denoting origin for the issued social security number. Required if
        ///     nationalIdentifier.socialSecurityNumber is set.
        /// </summary>
        public RegionInfo CountryCode { get; }

        /// <summary>
        ///     The social security number of the payer. Format: Norway DDMMYYXXXXX, Sweden: YYYYMMDDXXXX.
        /// </summary>
        public string SocialSecurityNumber { get; }
    }
}