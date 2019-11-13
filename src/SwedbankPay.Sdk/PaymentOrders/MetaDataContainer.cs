namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Collections.Generic;

    public class MetaDataContainer : IdLink
    {
        public Dictionary<string, object> MetaData { get; set; } //TODO Write doc
    }
}