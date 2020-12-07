namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationTransactionDto
    {
        public InvoicePaymentAuthorizationTransactionDto(IAuthorizationTransaction transaction)
        {
            Addressee = transaction.Addressee;
            City = transaction.City;
            CoAddress = transaction.CoAddress;
            CountryCode = transaction.CountryCode;
            CustomerNumber = transaction.CustomerNumber;
            Email = transaction.Email?.ToString();
            Ip = transaction.Ip;
            Msisdn = transaction.Msisdn?.ToString();
            SocialSecurityNumber = transaction.SocialSecurityNumber;
            StreetAddress = transaction.StreetAddress;
            TransactionActivity = transaction.TransactionActivity.Value;
            ZipCode = transaction.ZipCode;
        }

        public string Addressee { get; }

        public string City { get; }

        public string CoAddress { get; }

        public string CountryCode { get; }

        public int? CustomerNumber { get; }

        public string Email { get; }

        public string Ip { get; }

        public string Msisdn { get; }

        public int SocialSecurityNumber { get; }

        public string StreetAddress { get; }

        public string TransactionActivity { get; }

        public string ZipCode { get; }
    }
}