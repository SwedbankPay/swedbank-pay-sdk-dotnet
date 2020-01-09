using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PricesListResponse : IdLink
    {
        public PricesListResponse(List<Price> priceList)
        {
            PriceList = priceList;
        }

        public List<Price> PriceList { get; }
    }
}