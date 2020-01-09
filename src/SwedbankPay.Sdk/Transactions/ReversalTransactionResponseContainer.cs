using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalTransactionResponseContainer
    {
        public ReversalTransactionResponseContainer(Uri payment, TransactionContainer reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }


        public Uri Payment { get; }
        public TransactionContainer Reversal { get; }
    }
}