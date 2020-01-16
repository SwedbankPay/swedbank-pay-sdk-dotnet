using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class MetaDataResponse : Dictionary<string, object>
    {
        [JsonConstructor]
        public MetaDataResponse(Dictionary<string, object> dictionary)
            : base(dictionary)
        {
            Id = dictionary["id"]?.ToString();
        }

        public string Id { get; }
    }
}