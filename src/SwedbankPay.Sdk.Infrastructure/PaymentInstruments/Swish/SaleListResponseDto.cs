using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SaleListResponseDto
    {
        public List<SaleListItemDto> Sales { get; set; }
        
        internal ISaleListResponse Map()
        {
            var saleList = new List<ISaleListItem>();
            foreach (var item in Sales)
            {
                saleList.Add(new SaleListItem(item.Date,
                                               item.PaymentRequestToken,
                                               item.PayerAlias,
                                               item.SwishPaymentReference,
                                               item.SwishStatus,
                                               item.Id,
                                               item.Transaction.Map()));
            }
            return new SwishPaymentSaleListResponse(saleList);
        }
    }
}