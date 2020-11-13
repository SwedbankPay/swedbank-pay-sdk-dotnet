namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class ApprovedLegalAddress
    {
        public ApprovedLegalAddress(string socialSecurityNumber, string zipCode)
        {
            SocialSecurityNumber = socialSecurityNumber;
            ZipCode = zipCode;
        }

        /// <summary>
        /// The payers social security number.
        /// </summary>
        public string SocialSecurityNumber { get; }

        /// <summary>
        /// The payers zip code.
        /// </summary>
        public string ZipCode { get; }
    }
}