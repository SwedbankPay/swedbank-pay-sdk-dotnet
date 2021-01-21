using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentAuthorizationListResponse : IPaymentAuthorizationListResponse
    {
        public PaymentAuthorizationListResponse(Uri id, List<IPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }

        public Uri Id { get; }

        public IList<IPaymentAuthorization> AuthorizationList { get; }
    }
}