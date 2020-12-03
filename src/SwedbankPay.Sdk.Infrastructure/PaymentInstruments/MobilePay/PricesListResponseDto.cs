using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class PricesListResponseDto
    {
        public List<PriceDto> PriceList { get; set; } = new List<PriceDto>();

        internal IPricesListResponse Map()
        {
            var priceList = new List<IPrice>();
            foreach (var item in PriceList)
            {
                PriceType priceType;
                if (string.IsNullOrEmpty(item.Type))
                {
                    priceType = PriceType.Unknown;
                }
                else
                {
                    priceType = Enum.Parse<PriceType>(item.Type);
                }
                    
                priceList.Add(new Price(item.Amount, priceType, item.Amount));
            }
            return new PricesListResponse(priceList);
        }
    }
}