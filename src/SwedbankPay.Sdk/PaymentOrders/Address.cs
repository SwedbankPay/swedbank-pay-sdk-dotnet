using SwedbankPay.Sdk.Consumers;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Address
    {
        public string City { get; set; }
        public string CoAddress { get; set; }
        public CountryCode CountryCode { get; set; }
        public EmailAddress Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Msisdn Msisdn { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
    }
}