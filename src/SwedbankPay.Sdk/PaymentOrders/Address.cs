namespace SwedbankPay.Sdk.PaymentOrders
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SwedbankPay.Sdk.Consumers;

    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Msisdn { get; set; }
        public string StreetAddress { get; set; }
        public string CoAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; }
    }
}