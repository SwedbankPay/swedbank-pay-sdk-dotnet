using System;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class ReversalResponseContainer
    {
        public ReversalResponseContainer(Uri payment, ReversalResponse reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }

        public Uri Payment { get; }
        public ReversalResponse Reversal { get; }
    }
}
