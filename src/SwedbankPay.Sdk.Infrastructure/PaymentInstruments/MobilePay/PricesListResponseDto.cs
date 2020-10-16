using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class PricesListResponseDto
    {
        public List<PriceDto> PriceList { get; }

        internal IPricesListResponse Map()
        {
            var priceList = new List<IPrice>();
            foreach (var item in PriceList)
            {
                var priceType = Enum.Parse<PriceType>(item.Type);
                priceList.Add(new Price(item.Amount, priceType, item.Amount));
            }
            return new PricesListResponse(priceList);
        }
    }
}