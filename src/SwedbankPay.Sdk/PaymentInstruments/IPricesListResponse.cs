using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPricesListResponse
    {
        List<IPrice> PriceList { get; }
    }
}