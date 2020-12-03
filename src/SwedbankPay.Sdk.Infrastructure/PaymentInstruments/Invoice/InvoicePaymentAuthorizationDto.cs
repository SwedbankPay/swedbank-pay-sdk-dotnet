namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationDto
    {
        public string Addressee { get; set; }
        public string City { get; set; }
        public string CoAddress { get; set; }
        public string CountryCode { get; set; }
        public int? CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string Msisdn { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string StreetAddress { get; set; }
        public string TransactionActivity { get; set; }
        public string ZipCode { get; set; }

        internal IAuthorizationTransaction Map()
        {
            return new AuthorizationTransaction(this);
        }
    }
}