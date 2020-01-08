namespace SwedbankPay.Sdk.Payments.Card
{
    public class Cardholder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailAddress Email { get; set; }
        public Msisdn Msisdn { get; set; }
        public Msisdn HomePhoneNumber { get; set; }
        public Msisdn WorkPhoneNumber { get; set; }
        public Address Shippingaddress  { get; set; }
        public Address BillingAddress { get; set; }
        public AccountInfo AccountInfo { get; set; }
    }
}