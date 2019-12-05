namespace SwedbankPay.Sdk.Transactions
{
    using System;

    using Newtonsoft.Json;

    public class ReversalTransactionResponseContainer
    {
        public Uri Payment { get; }
        public TransactionContainer Reversal { get; }


        public ReversalTransactionResponseContainer()
        {
        }

        [JsonConstructor]
        public ReversalTransactionResponseContainer(Uri payment, TransactionContainer reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }
    }
}