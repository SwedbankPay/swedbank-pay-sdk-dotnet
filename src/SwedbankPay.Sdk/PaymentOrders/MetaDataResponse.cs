using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class MetadataResponse : Dictionary<string, object>
    {
        [JsonConstructor]
        public MetadataResponse(Dictionary<string, object> dictionary)
            : base(dictionary)
        {
            Id = dictionary["id"]?.ToString();
        }

        public string Id { get; }
    }
}