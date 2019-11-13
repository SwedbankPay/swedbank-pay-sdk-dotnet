namespace SwedbankPay.Sdk.PaymentOrders
{
    public class NationalIdentifier
    {
        /// <summary>
        /// The social security number of the payer. Format: Norway DDMMYYXXXXX, Sweden: YYYYMMDDXXXX.
        /// </summary>
        public string SocialSecurityNumber { get; set; }

        /// <summary>
        /// The country code, denoting origin for the issued social security number. Required if nationalIdentifier.socialSecurityNumber is set.
        /// </summary>
        public string CountryCode { get; set; }
    }
}
