using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentSaleListResponse : Identifiable, ISwishSaleListResponse
    {
        public SwishPaymentSaleListResponse(Uri id, List<ISwishSaleListItem> saleList) : base(id)
        {
            SaleList = saleList;
        }

        /// <summary>
        /// A list of sale summary items.
        /// </summary>
        public List<ISwishSaleListItem> SaleList { get; }
    }
}