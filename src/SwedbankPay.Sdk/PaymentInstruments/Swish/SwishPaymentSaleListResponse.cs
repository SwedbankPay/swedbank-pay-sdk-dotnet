using SwedbankPay.Sdk.Common;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleListResponse : IdLink, ISwishSaleListResponse
    {
        public SwishPaymentSaleListResponse(List<ISwishSaleListItem> saleList)
        {
            SaleList = saleList;
        }

        public List<ISwishSaleListItem> SaleList { get; }
    }
}