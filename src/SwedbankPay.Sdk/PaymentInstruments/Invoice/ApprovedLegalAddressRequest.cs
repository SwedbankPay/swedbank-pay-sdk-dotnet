namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Transactional details for getting approved legal address of a payer.
    /// </summary>
    public class ApprovedLegalAddressRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="ApprovedLegalAddressRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="socialSecurityNumber">The payers social security number.</param>
        /// <param name="zipCode">The payers zip code.</param>
        public ApprovedLegalAddressRequest(string socialSecurityNumber, string zipCode)
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