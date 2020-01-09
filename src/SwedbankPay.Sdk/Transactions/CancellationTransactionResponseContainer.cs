using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class CancellationTransactionResponseContainer
    {
        public CancellationTransactionResponseContainer(Uri payment, TransactionContainer cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }

        public Uri Payment { get; }
        public TransactionContainer Cancellation { get; }
    }
}