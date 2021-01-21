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
                saleList.Add(new SwishSaleListItem(item.Id,
                                               item.Date,
                                               item.PaymentRequestToken,
                                               item.PayerAlias,
                                               item.SwishPaymentReference,
                                               item.SwishStatus,
                                               item.Transaction.Map()));
            }
            return new SwishPaymentSaleListResponse(Id, saleList);
        }
    }
}