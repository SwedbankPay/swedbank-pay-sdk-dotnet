using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PricesListResponse : Identifiable, IPricesListResponse
    {
        public PricesListResponse(Uri id, List<IPrice> priceList) : base(id)
        {
            PriceList = priceList;
        }


        public List<IPrice> PriceList { get; }
    }
}