using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class SalesTransactionListResponseDto
    {
        public IdLink Id { get; set; }
        public string Payment { get; set; }
        public List<PaymentOrderTransactionDto> Sale { get; set; }

        internal ISaleListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}