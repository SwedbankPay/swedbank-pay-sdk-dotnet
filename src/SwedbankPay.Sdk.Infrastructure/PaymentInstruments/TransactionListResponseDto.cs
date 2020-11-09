using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class TransactionListResponseDto
    {
        public Uri Id { get; set; }

        public List<TransactionDto> TransactionList { get; set; } = new List<TransactionDto>();

        internal ITransactionListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in TransactionList)
            {
                transactionList.Add(t.Map());
            }
            return new TransactionListResponse(Id, transactionList);
        }
    }
}