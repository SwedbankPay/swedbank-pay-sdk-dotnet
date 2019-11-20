namespace SwedbankPay.Sdk.Transactions
{
    internal class AllTransactionResponseContainer
    {
        public string Payment { get; }
        public TransactionListContainer Transactions { get; }


        public AllTransactionResponseContainer(string payment, TransactionListContainer transactions)
        {
            Payment = payment;
            Transactions = transactions;
        }
        
        public AllTransactionResponseContainer()
        {
            
        }
    }
}