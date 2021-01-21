using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationList : Identifiable, ICardPaymentAuthorizationList
    {
        public CardPaymentAuthorizationList(Uri id, List<IPaymentAuthorization> authorizationList) : base(id)
        {
            AuthorizationList = authorizationList;
        }

        public IList<IPaymentAuthorization> AuthorizationList { get; }
    }
}