using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CancellationListResponseDto
    {
        public List<TransactionDto> CancellationList { get; set; }
        public Uri Id { get; set; }

        internal ICancellationListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in CancellationList)
            {
                transactionList.Add(t.Map());
            }
            return new CancellationListResponse(Id, transactionList);
        }
    }
}