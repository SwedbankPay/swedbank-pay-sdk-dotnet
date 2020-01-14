using System;

namespace SwedbankPay.Sdk.Payments
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