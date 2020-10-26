using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CancellationTransactionResponseDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> Cancellations { get; set; }

        internal ICancellationsListResponse Map()
        {
            var list = new List<ITransaction>();
            foreach (var c in Cancellations)
            {
                list.Add(c.Map());
            }
            return new CancellationsListResponse(Id, list);
        }
    }

}