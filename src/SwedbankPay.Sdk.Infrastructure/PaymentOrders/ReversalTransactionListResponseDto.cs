using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class ReversalTransactionListResponseDto
    {
        public IdLink Id { get; set; }
        public string Payment { get; set; }
        public List<TransactionDto> Reversal { get; set; }

        internal IReversalsListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}