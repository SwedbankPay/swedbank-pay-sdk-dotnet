using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SaleListResponse : IdLink
    {
        public SaleListResponse(Uri id, List<SaleListItem> saleList)
        {
            Id = id;
            SaleList = saleList;
        }


        public List<SaleListItem> SaleList { get; }
    }
}