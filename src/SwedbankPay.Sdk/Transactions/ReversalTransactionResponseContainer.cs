namespace SwedbankPay.Sdk.Transactions
{
    internal class ReversalTransactionResponseContainer
    {
        public string Payment { get; set; }
        public TransactionContainer Reversal { get; set; }
    }
}