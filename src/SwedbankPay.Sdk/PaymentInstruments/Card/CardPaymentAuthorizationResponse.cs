using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationResponse : ICardPaymentAuthorizationResponse
    {
        public CardPaymentAuthorizationResponse(Uri payment, CardPaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public CardPaymentAuthorization Authorization { get; }

        public Uri Payment { get; }
    }
}