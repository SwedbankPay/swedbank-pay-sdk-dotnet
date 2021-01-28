using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationListResponse : Identifiable, ICardPaymentAuthorizationListResponse
    {
        public CardPaymentAuthorizationListResponse(Uri id, List<IPaymentAuthorization> authorizationList) : base(id)
        {
            AuthorizationList = authorizationList;
        }

        public IList<IPaymentAuthorization> AuthorizationList { get; }
    }
}