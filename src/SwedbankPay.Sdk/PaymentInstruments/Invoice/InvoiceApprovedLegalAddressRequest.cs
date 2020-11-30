namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoiceApprovedLegalAddressRequest
    {
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