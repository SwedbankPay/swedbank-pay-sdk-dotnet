namespace SwedbankPay.Sdk.Transactions
{
    using System;

    using Newtonsoft.Json;

    internal class AllTransactionResponseContainer
    {
        public Uri Payment { get; }
        public TransactionListContainer Transactions { get; }

        public AllTransactionResponseContainer()
        {
        }

        [JsonConstructor]
        public AllTransactionResponseContainer(Uri payment, TransactionListContainer transactions)
        {
            Payment = payment;
            Transactions = transactions;
        }
    }
}