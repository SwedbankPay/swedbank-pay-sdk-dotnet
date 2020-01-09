using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class CancellationTransactionResponse
    {
        public CancellationTransactionResponse(Uri payment, TransactionResponse cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }

        public Uri Payment { get; }
        public TransactionResponse Cancellation { get; }
    }
}