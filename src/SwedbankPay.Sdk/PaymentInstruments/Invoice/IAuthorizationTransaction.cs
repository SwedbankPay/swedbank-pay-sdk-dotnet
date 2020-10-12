namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IAuthorizationTransaction
    {
        string Addressee { get; }
        string City { get; }
        string CoAddress { get; }
        string CountryCode { get; }
        int? CustomerNumber { get; }
        EmailAddress Email { get; }
        string Ip { get; }
        string Msisdn { get; }
        int SocialSecurityNumber { get; }
        string StreetAddress { get; }
        Operation TransactionActivity { get; }
        string ZipCode { get; }
    }
}