using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SaleListResponseDto
    {
        public string Id { get; set; }
        public List<SaleListItemDto> Sales { get; set; } = new List<SaleListItemDto>();

        internal ISwishSaleListResponse Map()
        {
            var saleList = new List<ISwishSaleListItem>();
            foreach (var item in Sales)
            {
                var saleItem = new SwishSaleListItem(item);
                saleList.Add(saleItem);
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new SwishPaymentSaleListResponse(uri, saleList);
        }
    }
}