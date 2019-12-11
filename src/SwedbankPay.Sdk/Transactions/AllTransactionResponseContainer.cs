using System;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    internal class AllTransactionResponseContainer
    {
        public AllTransactionResponseContainer()
        {
        }


        [JsonConstructor]
        public AllTransactionResponseContainer(Uri payment, TransactionListContainer transactions)
        {
            Payment = payment;
            Transactions = transactions;
        }


        public Uri Payment { get; }
        public TransactionListContainer Transactions { get; }
    }
}