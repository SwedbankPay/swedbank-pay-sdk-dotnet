using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class PricesListResponse : Identifiable, IPricesListResponse
    {
        public PricesListResponse(List<IPrice> priceList)
        {
            PriceList = priceList;
        }


        public List<IPrice> PriceList { get; }
    }
}