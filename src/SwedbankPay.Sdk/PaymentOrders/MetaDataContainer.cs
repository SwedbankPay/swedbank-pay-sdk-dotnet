using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class MetaDataContainer
    {
        /// <summary>
        ///     The keys and values that should be associated with the payment order. Can be additional identifiers and data you
        ///     want to associate with the payment.
        /// </summary>
        public Dictionary<string, object> MetaData { get; set; }
    }
}