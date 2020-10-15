using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
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