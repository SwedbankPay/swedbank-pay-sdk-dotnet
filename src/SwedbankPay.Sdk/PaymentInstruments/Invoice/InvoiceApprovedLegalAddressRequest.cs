namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Wrapper for requesting a payers legal address for invocing.
    /// </summary>
    public class InvoiceApprovedLegalAddressRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="InvoiceApprovedLegalAddressRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="socialSecurityNumber">The payers social security number.</param>
        /// <param name="zipCode">The payers zip code.</param>
        public InvoiceApprovedLegalAddressRequest(string socialSecurityNumber, string zipCode)
        {
            Addressee = new ApprovedLegalAddressRequest(socialSecurityNumber, zipCode);
        }

        /// <summary>
        /// The addressee you want the approved legal address for.
        /// </summary>
        public ApprovedLegalAddressRequest Addressee { get; }
    }
}