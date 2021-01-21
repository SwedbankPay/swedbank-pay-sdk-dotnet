using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class CancellationTransactionResponseDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> Cancellations { get; set; }

        internal ICancellationsList Map()
        {
            var list = new List<ITransaction>();
            foreach (var c in Cancellations)
            {
                list.Add(c.Map());
            }
            return new CancellationsList(Id, list);
        }
    }

}