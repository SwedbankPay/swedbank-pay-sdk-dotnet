using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class PricesListResponse : Identifiable, IPricesListResponse
    {
        public PricesListResponse(List<IPrice> priceList)
        {
            PriceList = priceList;
        }


        public List<IPrice> PriceList { get; }
    }
}