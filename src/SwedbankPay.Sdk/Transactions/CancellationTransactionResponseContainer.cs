namespace SwedbankPay.Sdk.Transactions
{
    using System;

    using Newtonsoft.Json;

    internal class CancellationTransactionResponseContainer
    {
        public Uri Payment { get; }
        public TransactionContainer Cancellation { get; }
        
        public CancellationTransactionResponseContainer()
        {
        }
        
        [JsonConstructor]
        public CancellationTransactionResponseContainer(string payment, TransactionContainer cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }
    }
}