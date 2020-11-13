namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoiceApprovedLegalAddressRequest
    {
        public InvoiceApprovedLegalAddressRequest(string socialSecurityNumber, string zipCode)
        {
            Addressee = new ApprovedLegalAddress(socialSecurityNumber, zipCode);
        }

        /// <summary>
        /// The addressee you want the approved legal address for.
        /// </summary>
        public ApprovedLegalAddress Addressee { get; }
    }
}