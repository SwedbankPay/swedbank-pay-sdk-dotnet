namespace SwedbankPay.Sdk.Payments.InvoicePayments
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