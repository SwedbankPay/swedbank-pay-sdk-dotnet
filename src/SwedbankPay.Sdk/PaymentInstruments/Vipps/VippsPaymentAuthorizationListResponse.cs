using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationListResponse : IdLink, IVippsPaymentAuthorizationListResponse
    {
        public VippsPaymentAuthorizationListResponse(Uri id, List<IVippsPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<IVippsPaymentAuthorization> AuthorizationList { get; }
    }
}