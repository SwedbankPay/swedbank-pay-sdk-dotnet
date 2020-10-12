using System;
using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.Payments
{
    public class PricesDto: IdLink
    {
        public List<PriceListDto> PriceList { get; set; }

        internal IPricesListResponse Map()
        {
            var priceList = PriceList.Select(a => new Price(a.Amount, Enum.Parse<PriceType>(a.Type), a.VatAmount)).ToList();
            var list = new PricesListResponse(priceList);
            list.Id = Id;
            return list;
        }
    }
}