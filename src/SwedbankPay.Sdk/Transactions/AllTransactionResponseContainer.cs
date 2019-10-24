namespace SwedbankPay.Sdk.Transactions
{
    internal class AllTransactionResponseContainer
    {
        public string Payment { get; set; }
        public TransactionListContainer Transactions { get; set; } 

    }
}