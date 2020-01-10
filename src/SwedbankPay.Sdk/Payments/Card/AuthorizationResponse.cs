using System;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class AuthorizationResponse
    {
        public AuthorizationResponse(Uri payment, CapturesListResponse captures)
        {
            Payment = payment;
            Captures = captures;
        }


        public CapturesListResponse Captures { get; }

        public Uri Payment { get; }
    }
}