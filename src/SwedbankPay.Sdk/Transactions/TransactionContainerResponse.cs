using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionContainerResponse : IdLink
    {
        public TransactionContainerResponse(Uri id, TransactionResponse transaction)
        {
            Id = id;
            Transaction = transaction;
        }


        public TransactionResponse Transaction { get; }
    }
}