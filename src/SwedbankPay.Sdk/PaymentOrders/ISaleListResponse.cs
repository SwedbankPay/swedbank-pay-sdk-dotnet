using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ISaleListResponse
    {
        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this sale list.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// Contains all currently available sale list items for this payment order.
        /// </summary>
        public List<ISaleListItem> SaleList { get; }
    }
}