namespace SwedbankPay.Sdk.Models.Response
{
    using Newtonsoft.Json;

    public class BillingAddress
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Msisdn { get; set; }

        [JsonProperty("addressee")]
        public string Addressee { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        public string CoAddress { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
       
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}
