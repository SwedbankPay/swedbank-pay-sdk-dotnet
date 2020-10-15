namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoiceApprovedLegalAddressRequest
    {
        public InvoiceApprovedLegalAddressRequest(string socialSecurityNumber, string zipCode)
        {
            Addressee = new ApprovedLegalAddress(socialSecurityNumber, zipCode);
        }

        public ApprovedLegalAddress Addressee { get; }
    }
}