using SwedbankPay.Sdk.Common;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleListResponse: IdLink, ISaleListResponse
    {
        public SwishPaymentSaleListResponse(List<ISaleListItem> saleList)
        {
            SaleList = saleList;
        }

        public List<ISaleListItem> SaleList { get; }
    }
}