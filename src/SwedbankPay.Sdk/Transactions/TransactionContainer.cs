using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionContainer : IdLink
    {
        public TransactionContainer(Uri id, TransactionResponse transaction)
        {
            Id = id;
            Transaction = transaction;
        }

        public TransactionResponse Transaction { get; }
    }
}