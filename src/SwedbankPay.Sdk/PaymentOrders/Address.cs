namespace SwedbankPay.Sdk.PaymentOrders
{
    using SwedbankPay.Sdk.Consumers;

    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailAddress Email { get; set; }
        public Msisdn Msisdn { get; set; }
        public string StreetAddress { get; set; }
        public string CoAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public CountryCode CountryCode { get; set; }
    }
}