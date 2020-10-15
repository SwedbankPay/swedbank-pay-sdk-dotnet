using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IPricesListResponse
    {
        List<IPrice> PriceList { get; }
    }
}