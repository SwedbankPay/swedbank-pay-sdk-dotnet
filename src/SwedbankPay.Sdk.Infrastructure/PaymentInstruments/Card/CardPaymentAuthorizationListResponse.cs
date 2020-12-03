using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationListResponse : Identifiable, ICardPaymentAuthorizationListResponse
    {
        public CardPaymentAuthorizationListResponse(List<IPaymentAuthorization> authorizationList)
        {
            AuthorizationList = authorizationList;
        }

        public List<IPaymentAuthorization> AuthorizationList { get; }
    }
}