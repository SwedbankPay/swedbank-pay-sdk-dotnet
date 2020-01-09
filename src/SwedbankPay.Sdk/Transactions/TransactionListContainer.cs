using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionListContainer : IdLink
    {
        public TransactionListContainer(Uri id, List<TransactionResponse> transactionList)
        {
            Id = id;
            TransactionList = transactionList;
        }


        public List<TransactionResponse> TransactionList { get; }
    }
}