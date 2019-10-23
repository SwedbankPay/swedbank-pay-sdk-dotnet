namespace SwedbankPay.Sdk.Models.Response
{
    using Newtonsoft.Json;

    public class BillingDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }
        [JsonProperty("billingAddress")]
        public BillingAddress BillingAddress { get; set; }
    }
}
