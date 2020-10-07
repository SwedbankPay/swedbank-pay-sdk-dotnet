using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class MetadataResponse : Dictionary<string, object>
    {
        public MetadataResponse(Dictionary<string, object> dictionary)
            : base(dictionary)
        {
            Id = dictionary["id"]?.ToString();
        }

        public string Id { get; }
    }
}