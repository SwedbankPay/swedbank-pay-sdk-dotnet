using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PricesListResponseDto
    {
        public List<PriceDto> Prices { get; set; }
        internal IPricesListResponse Map()
        {
            var list = new List<IPrice>();
            foreach (var p in Prices)
            {
                var type = Enum.Parse<PriceType>(p.Type);
                list.Add(new Price(p.Amount, type, p.VatAmount));
            }
            return new PricesListResponse(list);
        }
    }
}