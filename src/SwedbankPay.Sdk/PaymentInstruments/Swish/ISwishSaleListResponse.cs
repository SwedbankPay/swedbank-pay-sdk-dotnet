using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishSaleListResponse
    {
        /// <summary>
        /// A URI to get details about this sale list item.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// A list of Swish sale list items.
        /// </summary>
        public List<ISwishSaleListItem> SaleList { get; }
    }
}