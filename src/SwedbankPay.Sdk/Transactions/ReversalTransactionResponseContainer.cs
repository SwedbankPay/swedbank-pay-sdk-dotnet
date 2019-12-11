using System;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalTransactionResponseContainer
    {
        public ReversalTransactionResponseContainer()
        {
        }


        [JsonConstructor]
        public ReversalTransactionResponseContainer(Uri payment, TransactionContainer reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }


        public Uri Payment { get; }
        public TransactionContainer Reversal { get; }
    }
}