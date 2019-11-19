namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Collections.Generic;

    public class MetaDataContainer : IdLink
    {
        /// <summary>
        /// The keys and values that should be associated with the payment order. Can be additional identifiers and data you want to associate with the payment.
        /// </summary>
        public Dictionary<string, object> MetaData { get; set; }
    }
}