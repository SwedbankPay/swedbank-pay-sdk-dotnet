using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalTransactionResponse
    {
        public ReversalTransactionResponse(Uri payment, TransactionResponse reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }


        public Uri Payment { get; }
        public TransactionResponse Reversal { get; }
    }
}