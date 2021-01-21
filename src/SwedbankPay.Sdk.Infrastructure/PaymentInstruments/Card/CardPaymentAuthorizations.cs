using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizations
    {
        public CardPaymentAuthorizations(Uri payment, ICardPaymentAuthorizationList authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public ICardPaymentAuthorizationList AuthorizationList { get; }

        public Uri Payment { get; }
    }
}