using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationListResponse : IdLink, ICardPaymentAuthorizationListResponse
    {
        public CardPaymentAuthorizationListResponse(List<Payments.TransactionDto> authorizations)
        {
        }

        public CardPaymentAuthorizationListResponse(Uri id, List<CardPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<CardPaymentAuthorization> AuthorizationList { get; }
    }
}