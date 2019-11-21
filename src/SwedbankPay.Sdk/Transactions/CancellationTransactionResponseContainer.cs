namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    internal class CancellationTransactionResponseContainer
    {
        public string Payment { get; }
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