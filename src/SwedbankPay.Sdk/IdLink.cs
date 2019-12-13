using System;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class IdLink
    {
        /// <summary>
        ///     Relative URL to some resource
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public Uri Id { get; protected set; }
        
    }
}