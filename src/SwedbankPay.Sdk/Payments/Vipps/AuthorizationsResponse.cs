using System;

namespace SwedbankPay.Sdk.Payments.Vipps
{
    public class AuthorizationsResponse
    {
        public AuthorizationsResponse(Uri payment, AuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public AuthorizationListResponse AuthorizationList { get; }

        public Uri Payment { get; }
    }
}