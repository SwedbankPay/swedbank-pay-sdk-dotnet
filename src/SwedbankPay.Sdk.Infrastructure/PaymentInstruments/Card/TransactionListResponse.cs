using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class TransactionListResponse : Identifiable, ITransactionListResponse
    {
        public TransactionListResponse(Uri id, List<ITransaction> transactionList)
        {
            Id = id;
            TransactionList = transactionList;
        }


        public List<ITransaction> TransactionList { get; }
    }
}