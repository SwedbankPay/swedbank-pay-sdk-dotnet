using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationListResponse : IdLink, ICardPaymentAuthorizationListResponse
    {
        public List<CardPaymentAuthorization> AuthorizationList { get; }
    }
}