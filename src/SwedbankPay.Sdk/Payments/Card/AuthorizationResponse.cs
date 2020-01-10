using System;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class AuthorizationResponse
    {
        public AuthorizationResponse(Uri payment, Authorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }

        public Uri Payment { get; }
        public Authorization Authorization { get; }
    }
}