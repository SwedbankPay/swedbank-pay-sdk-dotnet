namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class ApprovedLegalAddress
    {
        public ApprovedLegalAddress(string socialSecurityNumber, string zipCode)
        {
            SocialSecurityNumber = socialSecurityNumber;
            ZipCode = zipCode;
        }

        public string SocialSecurityNumber { get; }
        public string ZipCode { get; }
    }
}