namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    public class ShippingDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }
    }
}
