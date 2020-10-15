using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PricesDto: IdLink
    {
        public List<PriceListDto> PriceList { get; set; }

        internal IPricesListResponse Map()
        {
            var listPrice = new List<IPrice>();
            foreach (var item in PriceList)
            {
                listPrice.Add(new Price(item.Amount, Enum.Parse<PriceType>(item.Type), item.VatAmount));
            }
            return new PricesListResponse(listPrice)
            {
                Id = Id
            };
        }
    }
}