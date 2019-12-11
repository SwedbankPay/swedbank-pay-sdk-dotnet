using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class IdLink
    {
        /// <summary>
        ///     Relative URL to some resource
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; protected set; }
    }
}