using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentSaleListResponse : IdLink
    {
        public SwishPaymentSaleListResponse(Uri id, List<SaleListItem> saleList)
        {
            Id = id;
            SaleList = saleList;
        }


        public List<SaleListItem> SaleList { get; }
    }
}