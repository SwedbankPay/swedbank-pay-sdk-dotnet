using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationsResponse
    {
        public CardPaymentAuthorizationsResponse(Uri payment, ICardPaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public ICardPaymentAuthorizationListResponse AuthorizationList { get; }

        public Uri Payment { get; }
    }
}