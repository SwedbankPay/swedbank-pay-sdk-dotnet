namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoiceApprovedLegalAddressRequest
    {
        public InvoiceApprovedLegalAddressRequest(string socialSecurityNumber, string zipCode)
        {
            Addressee = new ApprovedLegalAddress(socialSecurityNumber, zipCode);
        }

        public ApprovedLegalAddress Addressee { get; }

        public class ApprovedLegalAddress
        {
            protected internal ApprovedLegalAddress(string socialSecurityNumber, string zipCode)
            {
                SocialSecurityNumber = socialSecurityNumber;
                ZipCode = zipCode;
            }

            public string SocialSecurityNumber { get; }
            public string ZipCode { get; }
        }
    }
}