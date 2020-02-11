using System;

namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public class AuthorizationResponse
    {
        public AuthorizationResponse(Uri payment, Authorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public Authorization Authorization { get; }

        public Uri Payment { get; }
    }
}