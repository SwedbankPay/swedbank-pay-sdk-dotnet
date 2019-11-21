namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    internal class AllTransactionResponseContainer
    {
        public string Payment { get; }
        public TransactionListContainer Transactions { get; }

        public AllTransactionResponseContainer()
        {
        }

        [JsonConstructor]
        public AllTransactionResponseContainer(string payment, TransactionListContainer transactions)
        {
            Payment = payment;
            Transactions = transactions;
        }
    }
}