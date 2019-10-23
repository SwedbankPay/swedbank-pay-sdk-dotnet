namespace SwedbankPay.Sdk.Models.Request
{
    public class NationalIdentifier
    {
        public string SocialSecurityNumber { get; set; }

        /// <summary>
        /// The country code, denoting origin for the issued social security number. Required if nationalIdentifier.socialSecurityNumber is set.
        /// </summary>
        public string CountryCode { get; set; }
    }
}
