namespace SwedbankPay.Sdk.Transactions
{
    using System;

    using Newtonsoft.Json;

    internal class ReversalTransactionResponseContainer
    {
        public Uri Payment { get; }
        public TransactionContainer Reversal { get; }


        public ReversalTransactionResponseContainer()
        {
        }

        [JsonConstructor]
        public ReversalTransactionResponseContainer(string payment, TransactionContainer reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }
    }
}