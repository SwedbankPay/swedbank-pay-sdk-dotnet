using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class SalesTransactionListResponseDto
    {
        public Uri Id { get; set; }
        public string Payment { get; set; }
        public List<TransactionDto> Sale { get; set; } = new List<TransactionDto>();

        internal ISaleListResponse Map()
        {
            return new SaleListResponse(this);
        }
    }
}