using SwedbankPay.Sdk.Extensions;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PricesDto
    {
        public string Id { get; set; }

        public List<PriceListDto> PriceList { get; set; } = new List<PriceListDto>();

        internal IPriceListResponse Map()
        {
            var listPrice = new List<IPrice>();
            foreach (var item in PriceList)
            {
                listPrice.Add(new Price(item.Amount, item.Type.ParseTo<PriceType>(), item.VatAmount));
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new PriceListResponse(uri, listPrice);
        }
    }
}