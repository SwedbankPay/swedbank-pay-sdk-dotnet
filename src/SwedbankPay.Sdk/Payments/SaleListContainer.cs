using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class SaleListContainer : IdLink
    {
        public SaleListContainer(List<SaleListItem> saleList)
        {
            SaleList = saleList;
        }


        public List<SaleListItem> SaleList { get; }
    }
}