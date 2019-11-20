namespace SwedbankPay.Sdk
{
    using Newtonsoft.Json;

    public class IdLink
    {
        /// <summary>
        /// Relative URL to some resource
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; protected set; }
    }
}
