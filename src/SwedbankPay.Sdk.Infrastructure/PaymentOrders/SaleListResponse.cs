using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class SaleListResponse : ISaleListResponse
    {
        public SaleListResponse(SalesTransactionListResponseDto dto)
        {
            Id = dto.Id;
            Payment = dto.Payment;
            SaleList = new List<ISaleListItem>();
            foreach (var item in dto.Sale)
            {
                this.SaleList.Add(new SaleListItem(Id, item));
            }
            
        }

        public Uri Id { get; }
        public string Payment { get; }
        public List<ISaleListItem> SaleList { get; }
    }
}