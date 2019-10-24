namespace SwedbankPay.Sdk.Transactions
{
    internal class ReversalTransactionResponseContainer
    {
        public string Payment { get; protected set; }
        public TransactionContainer Reversal { get; protected set; }
    }
}