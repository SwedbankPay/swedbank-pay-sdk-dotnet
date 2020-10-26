using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SaleListResponseDto
    {
        public List<SaleListItemDto> Sales { get; set; }

        internal ISwishSaleListResponse Map()
        {
            var saleList = new List<ISwishSaleListItem>();
            foreach (var item in Sales)
            {
                saleList.Add(new SwishSaleListItem(item.Date,
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