using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PricesListResponseDto : List<PriceDto>
    {
        internal IPricesListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}