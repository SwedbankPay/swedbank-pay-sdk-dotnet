namespace SwedbankPay.Sdk.Transactions
{
    internal class AllTransactionResponseContainer
    {
        public string Payment { get; protected set; }
        public TransactionListContainer Transactions { get; protected set; } 

    }
}