using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationsResponse
    {
        public CardPaymentAuthorizationsResponse(Uri payment, ICardPaymentAuthorizationList authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public ICardPaymentAuthorizationList AuthorizationList { get; }

        public Uri Payment { get; }
    }
}