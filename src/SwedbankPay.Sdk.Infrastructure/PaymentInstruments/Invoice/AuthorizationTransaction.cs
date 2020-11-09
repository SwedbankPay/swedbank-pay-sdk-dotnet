namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class AuthorizationTransaction : IAuthorizationTransaction
    {
        public AuthorizationTransaction(InvoicePaymentAuthorizationDto item)
        {
            Addressee = item.Addressee;
            City = item.City;
            CoAddress = item.CoAddress;
            CountryCode = item.CountryCode;
            CustomerNumber = item.CustomerNumber;
            Email = new EmailAddress(item.Email);
            Ip = item.Ip;
            Msisdn = item.Msisdn;
            SocialSecurityNumber = item.SocialSecurityNumber;
            StreetAddress = item.StreetAddress;
            TransactionActivity = item.TransactionActivity;
            ZipCode = item.ZipCode;
        }

        public int SocialSecurityNumber { get; }
        
        public int? CustomerNumber { get; }
        
        public string Msisdn { get; }
        
        public string Ip { get; }
        
        public Operation TransactionActivity { get; }
        
        public EmailAddress Email { get; }
        
        public string Addressee { get; }
        
        public string StreetAddress { get; }
        
        public string ZipCode { get; }
        
        public string City { get; }
        
        public string CountryCode { get; }
        
        public string CoAddress { get; }
    }
}