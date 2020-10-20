using SwedbankPay.Sdk.Common;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationListResponse : IdLink, ICardPaymentAuthorizationListResponse
    {
        public CardPaymentAuthorizationListResponse(List<IPaymentAuthorization> authorizationList)
        {
            AuthorizationList = authorizationList;
        }

        public List<IPaymentAuthorization> AuthorizationList { get; }
    }
}