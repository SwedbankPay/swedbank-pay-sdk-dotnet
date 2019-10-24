namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    public class BillingDetails
    {
        [JsonProperty("email")]
        public string Email { get; protected set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; protected set; }
        [JsonProperty("billingAddress")]
        public Address BillingAddress { get; protected set; }
    }
}
