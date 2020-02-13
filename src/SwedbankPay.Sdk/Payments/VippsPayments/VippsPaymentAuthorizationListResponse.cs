using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.Vipps
{
    public class VippsPaymentAuthorizationListResponse : IdLink
    {
        public VippsPaymentAuthorizationListResponse(Uri id, List<VippsPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<VippsPaymentAuthorization> AuthorizationList { get; }
    }
}