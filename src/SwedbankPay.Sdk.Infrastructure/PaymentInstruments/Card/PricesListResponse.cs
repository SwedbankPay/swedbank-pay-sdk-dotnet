using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PricesListResponse : IdLink, IPricesListResponse
    {
        public PricesListResponse(List<IPrice> priceList)
        {
            PriceList = priceList;
        }


        public List<IPrice> PriceList { get; }
    }
}