using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationsResponse
    {
        public CardPaymentAuthorizationsResponse(Uri payment, CardPaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public CardPaymentAuthorizationListResponse AuthorizationList { get; }

        public Uri Payment { get; }
    }
}