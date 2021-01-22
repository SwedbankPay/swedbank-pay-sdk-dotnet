using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SaleListResponseDto
    {
        public Uri Id { get; set; }
        public List<SaleListItemDto> Sales { get; set; } = new List<SaleListItemDto>();

        internal ISwishSaleListResponse Map()
        {
            var saleList = new List<ISwishSaleListItem>();
            foreach (var item in Sales)
            {
                var saleItem = new SwishSaleListItem(item);
                saleList.Add(saleItem);
            }
            return new SwishPaymentSaleListResponse(Id, saleList);
        }
    }
}