using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class MetadataDto : Dictionary<string, string>
    {
        public string Id { get; set; }
    }
}