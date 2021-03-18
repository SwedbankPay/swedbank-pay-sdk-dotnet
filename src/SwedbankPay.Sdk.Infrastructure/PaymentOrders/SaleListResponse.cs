using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class SaleListResponse : ISaleListResponse
    {
        public SaleListResponse(SalesTransactionListResponseDto dto)
        {
            Id = new Uri(dto.Id, UriKind.RelativeOrAbsolute);
            Payment = dto.Payment;
            SaleList = new List<ISaleListItem>();
            foreach (var item in dto.Sale)
            {
                SaleList.Add(new SaleListItem(Id, item));
            }
        }

        public Uri Id { get; }
        public string Payment { get; }
        public IList<ISaleListItem> SaleList { get; }
    }
}