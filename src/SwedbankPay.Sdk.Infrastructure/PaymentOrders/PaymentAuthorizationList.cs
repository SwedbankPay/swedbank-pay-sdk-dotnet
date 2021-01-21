using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentAuthorizationList : IPaymentAuthorizationList
    {
        public PaymentAuthorizationList(Uri id, List<IPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }

        public Uri Id { get; }

        public IList<IPaymentAuthorization> AuthorizationList { get; }
    }
}