using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class SaleListContainer : IdLink
    {
        public SaleListContainer(List<SaleResponse> saleList)
        {
            SaleList = saleList;
        }


        public List<SaleResponse> SaleList { get; }
    }
}