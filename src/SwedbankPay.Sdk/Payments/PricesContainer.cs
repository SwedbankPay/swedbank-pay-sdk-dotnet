using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PricesContainer : IdLink
    {
        public PricesContainer(List<Price> priceList)
        {
            PriceList = priceList;
        }

        public List<Price> PriceList { get; }
    }
}