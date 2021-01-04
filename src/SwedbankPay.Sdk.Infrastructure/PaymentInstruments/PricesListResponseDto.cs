using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PricesListResponseDto
    {
        public Uri Id { get; set; }

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

                priceList.Add(new Price(item.Amount, priceType, item.VatAmount));
            }
            return new PricesListResponse(Id, priceList);
        }
    }
}