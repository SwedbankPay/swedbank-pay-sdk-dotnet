using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class AuthorizationTransactionResponseContainer
    {
        public AuthorizationTransactionResponseContainer(Uri payment, CapturesListContainer captures)
        {
            Payment = payment;
            Captures = captures;
        }

        public Uri Payment { get; }
        public CapturesListContainer Captures { get; }
    }
}
