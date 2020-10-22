using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationsListResponseDto
    {
        public List<TransactionDto> CancellationList { get; set; }
        public Uri Id { get; set; }

        internal ICancellationsListResponse Map()
        {
            var transactionList = new List<ITransactionResponse>();
            foreach (var t in CancellationList)
            {
                transactionList.Add(new TransactionResponse(Id, t));
            }
            return new CancellationsListResponse(Id, transactionList);
        }
    }
}