using System;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class CancellationTransactionResponseContainer
    {
        public CancellationTransactionResponseContainer()
        {
        }


        [JsonConstructor]
        public CancellationTransactionResponseContainer(Uri payment, TransactionContainer cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }


        public TransactionContainer Cancellation { get; }
        public Uri Payment { get; }
    }
}