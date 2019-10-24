namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    public class BillingDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }
        [JsonProperty("billingAddress")]
        public Address BillingAddress { get; set; }
    }
}
