using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SwedbankPay.Sdk.Consumers;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class NationalIdentifier
    {
        /// <summary>
        ///     The country code, denoting origin for the issued social security number. Required if
        ///     nationalIdentifier.socialSecurityNumber is set.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; }

        /// <summary>
        ///     The social security number of the payer. Format: Norway DDMMYYXXXXX, Sweden: YYYYMMDDXXXX.
        /// </summary>
        public string SocialSecurityNumber { get; set; }
    }
}