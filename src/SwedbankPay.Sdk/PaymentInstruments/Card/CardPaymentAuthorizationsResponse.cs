using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationsResponse
    {
        public CardPaymentAuthorizationsResponse(Uri payment, IPaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public IPaymentAuthorizationListResponse AuthorizationList { get; }

        public Uri Payment { get; }
    }
}