namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Information about a card holder
    /// </summary>
    public class Cardholder : ICardholder
    {
        public AccountInfo AccountInfo { get; set; }
        public Address BillingAddress { get; set; }
        public EmailAddress Email { get; set; }
        public string FirstName { get; set; }
        public Msisdn HomePhoneNumber { get; set; }
        public string LastName { get; set; }
        public Msisdn Msisdn { get; set; }
        public Address Shippingaddress { get; set; }
        public Msisdn WorkPhoneNumber { get; set; }
    }
}