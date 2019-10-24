namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    public class ShippingDetails
    {
        [JsonProperty("email")]
        public string Email { get; protected set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; protected set; }
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; protected set; }
    }
}
