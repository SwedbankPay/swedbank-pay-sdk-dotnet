using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API resource giving access to currently available list of <seealso cref="ISaleListItem"/>.
    /// </summary>
    public interface ISaleListResponse
    {
        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this sale list.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// Contains all currently available sale list items for this payment order.
        /// </summary>
        public IList<ISaleListItem> SaleList { get; }
    }
}