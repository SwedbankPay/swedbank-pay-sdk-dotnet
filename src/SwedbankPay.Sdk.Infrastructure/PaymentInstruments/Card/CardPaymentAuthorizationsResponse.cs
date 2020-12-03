using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationsResponse
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