using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleListResponse : Identifiable, ISwishSaleListResponse
    {
        public SwishPaymentSaleListResponse(List<ISwishSaleListItem> saleList)
        {
            SaleList = saleList;
        }

        /// <summary>
        /// A list of sale summary items.
        /// </summary>
        public List<ISwishSaleListItem> SaleList { get; }
    }
}