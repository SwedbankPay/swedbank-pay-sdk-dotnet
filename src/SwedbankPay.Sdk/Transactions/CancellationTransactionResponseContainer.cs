namespace SwedbankPay.Sdk.Transactions
{
    using System;

    using Newtonsoft.Json;

    public class CancellationTransactionResponseContainer
    {
        public Uri Payment { get; }
        public TransactionContainer Cancellation { get; }
        
        public CancellationTransactionResponseContainer()
        {
        }
        
        [JsonConstructor]
        public CancellationTransactionResponseContainer(Uri payment, TransactionContainer cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }
    }
}