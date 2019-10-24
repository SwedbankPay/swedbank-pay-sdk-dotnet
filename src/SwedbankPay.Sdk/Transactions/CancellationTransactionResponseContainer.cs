namespace SwedbankPay.Sdk.Transactions
{
    internal class CancellationTransactionResponseContainer
    {
        public string Payment { get; protected set; }
        public TransactionContainer Cancellation { get; protected set; }
    }
}