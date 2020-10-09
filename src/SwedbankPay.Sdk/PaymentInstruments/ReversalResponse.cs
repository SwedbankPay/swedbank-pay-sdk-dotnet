using System;

namespace SwedbankPay.Sdk.Payments
{
    public class ReversalResponse
    {
        public ReversalResponse(Uri payment, TransactionResponse reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }


        public Uri Payment { get; }
        public TransactionResponse Reversal { get; }
    }
}