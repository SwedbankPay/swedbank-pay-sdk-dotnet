using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SwedbankPay.Sdk.Consumers;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class NationalIdentifier
    {
        public NationalIdentifier(CountryCode countryCode, string socialSecurityNumber)
        {
            CountryCode = countryCode;
            SocialSecurityNumber = socialSecurityNumber;
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