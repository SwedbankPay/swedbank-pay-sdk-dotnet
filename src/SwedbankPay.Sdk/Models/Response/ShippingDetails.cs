namespace SwedbankPay.Sdk.Models.Response
{
    using Newtonsoft.Json;

    public class ShippingDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }
        [JsonProperty("shippingAddress")]
        public ShippingAddress ShippingAddress { get; set; }
    }
}
