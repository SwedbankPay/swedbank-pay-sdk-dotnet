using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionResponse : IdLink
    {
        public TransactionResponse(Uri id, Transaction transaction)
        {
            Id = id;
            Transaction = transaction;
        }


        public Transaction Transaction { get; }
    }
}