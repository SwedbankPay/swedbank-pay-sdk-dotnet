using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentSaleList : Identifiable, ISwishSaleList
    {
        public SwishPaymentSaleList(Uri id, List<ISwishSaleListItem> saleList) : base(id)
        {
            SaleList = saleList;
        }

        /// <summary>
        /// A list of sale summary items.
        /// </summary>
        public IList<ISwishSaleListItem> SaleList { get; }
    }
}