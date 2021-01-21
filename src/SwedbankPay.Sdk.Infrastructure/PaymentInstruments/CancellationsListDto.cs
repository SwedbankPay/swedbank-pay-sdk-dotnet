using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CancellationsListDto
    {
        public List<TransactionDto> CancellationList { get; set; }
        public Uri Id { get; set; }

        internal ICancellationsList Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in CancellationList)
            {
                transactionList.Add(t.Map());
            }
            return new CancellationsList(Id, transactionList);
        }
    }
}