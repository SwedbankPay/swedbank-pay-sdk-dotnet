using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PricesDto
    {
        public Uri Id { get; set; }

        public List<PriceListDto> PriceList { get; set; } = new List<PriceListDto>();

        internal IPriceListResponse Map()
        {
            var listPrice = new List<IPrice>();
            foreach (var item in PriceList)
            {
                listPrice.Add(new Price(item.Amount, Enum.Parse<PriceType>(item.Type), item.VatAmount));
            }
            return new PriceListResponse(Id, listPrice);
        }
    }
}