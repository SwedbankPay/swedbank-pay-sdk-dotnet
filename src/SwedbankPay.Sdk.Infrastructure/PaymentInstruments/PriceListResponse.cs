using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class PriceListResponse : Identifiable, IPriceListResponse
{
    public PriceListResponse(Uri id, List<IPrice> priceList) : base(id)
    {
        PriceList = priceList;
    }


    public IList<IPrice> PriceList { get; }
}