namespace SwedbankPay.Sdk.Models.Response
{
    using Newtonsoft.Json;

    public class ShippingAddress
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Msisdn { get; set; }

        [JsonProperty("addressee")]
        public string Addressee { get; set; }

        [JsonProperty("coAddress")]
        public string CoAddress { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
        
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}