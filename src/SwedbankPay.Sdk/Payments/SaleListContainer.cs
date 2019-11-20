namespace SwedbankPay.Sdk.Payments
{
    using System.Collections.Generic;

    public class SaleListContainer : IdLink
    {
        public List<SaleResponse> SaleList { get; }


        public SaleListContainer(List<SaleResponse> saleList)
        {
            SaleList = saleList;
        }
    }
}