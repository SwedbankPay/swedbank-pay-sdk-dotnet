using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal interface IPaymentAuthorizationListResponse
    {
        public Uri Id { get; }
        public List<IPaymentAuthorization> AuthorizationList { get; }
    }
}