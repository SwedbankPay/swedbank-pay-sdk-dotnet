using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionContainer
    {
        public TransactionContainer(Uri id, TransactionResponse transaction)
        {
            Id = id;
            Transaction = transaction;
        }

        public Uri Id { get; }

        public TransactionResponse Transaction { get; }
    }
}