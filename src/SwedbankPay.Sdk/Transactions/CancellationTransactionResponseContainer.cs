namespace SwedbankPay.Sdk.Transactions
{
    internal class CancellationTransactionResponseContainer
    {
        public string Payment { get; set; }
        public TransactionContainer Cancellation { get; set; }
    }
}