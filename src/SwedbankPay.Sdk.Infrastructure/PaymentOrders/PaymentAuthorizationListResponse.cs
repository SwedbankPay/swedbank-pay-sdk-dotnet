using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentAuthorizationListResponse : IPaymentAuthorizationListResponse
    {
        public PaymentAuthorizationListResponse(Uri id, List<IPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }

        public Uri Id { get; }

        public List<IPaymentAuthorization> AuthorizationList { get; }
    }
}