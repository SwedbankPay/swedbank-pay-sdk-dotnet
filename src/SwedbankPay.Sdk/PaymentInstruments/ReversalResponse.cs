using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class ReversalResponse : IReversalResponse
    {
        public ReversalResponse(Uri payment, ITransactionResponse reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }


        public Uri Payment { get; }
        public ITransactionResponse Reversal { get; }
    }
}