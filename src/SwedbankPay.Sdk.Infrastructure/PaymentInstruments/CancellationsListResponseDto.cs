using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CancellationsListResponseDto
    {
        public List<TransactionDto> CancellationList { get; set; }
        public Uri Id { get; set; }

        internal ICancellationsListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in CancellationList)
            {
                transactionList.Add(t.Map());
            }
            return new CancellationsListResponse(Id, transactionList);
        }
    }
}