using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PriceListResponseDto
    {
        public string Id { get; set; }

        public List<PriceDto> PriceList { get; set; } = new List<PriceDto>();

        internal IPriceListResponse Map()
        {
            var priceList = new List<IPrice>();
            foreach (var item in PriceList)
            {
                if (!Enum.TryParse(item.Type, out PriceType priceType))
                {
                    priceType = PriceType.Unknown;
                }

                priceList.Add(new Price(item.Amount, priceType, item.VatAmount));
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new PriceListResponse(uri, priceList);
        }
    }
}