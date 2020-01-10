using System;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class AuthorizationsResponse
    {
        public AuthorizationsResponse(Uri payment, AuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }

        public Uri Payment { get; }
        public AuthorizationListResponse AuthorizationList { get; }
    }
}
