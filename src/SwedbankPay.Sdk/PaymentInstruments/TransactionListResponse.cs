using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class TransactionListResponse : IdLink
    {
        public TransactionListResponse(Uri id, List<Transaction> transactionList)
        {
            Id = id;
            TransactionList = transactionList;
        }


        public List<Transaction> TransactionList { get; }
    }
}