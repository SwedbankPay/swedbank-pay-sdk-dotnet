using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardholder
    {
        AccountInfo AccountInfo { get; set; }
        Address BillingAddress { get; set; }
        EmailAddress Email { get; set; }
        string FirstName { get; set; }
        Msisdn HomePhoneNumber { get; set; }
        string LastName { get; set; }
        Msisdn Msisdn { get; set; }
        Address Shippingaddress { get; set; }
        Msisdn WorkPhoneNumber { get; set; }
    }
}