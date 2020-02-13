using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentAuthorizationListResponse : IdLink
    {
        public MobilePayPaymentAuthorizationListResponse(Uri id, List<Authorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<Authorization> AuthorizationList { get; }
    }
}