using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CancellationTransactionResponseDto
    {
        public string Payment { get; set; }
        public List<TransactionDto> Cancellations { get; set; }

        internal ICancellationsListResponse Map()
        {
            throw new NotImplementedException();
        }
    }

}