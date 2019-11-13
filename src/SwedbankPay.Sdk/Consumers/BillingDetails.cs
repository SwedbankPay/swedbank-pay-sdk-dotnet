namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    public class BillingDetails
    {
        [JsonProperty("email")]
        public string Email { get; protected set; }
        /// <summary>
        /// The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
        /// </summary>
        [JsonProperty("msisdn")]
        public string Msisdn { get; protected set; }
        [JsonProperty("billingAddress")]
        public Address BillingAddress { get; protected set; }
    }
}
