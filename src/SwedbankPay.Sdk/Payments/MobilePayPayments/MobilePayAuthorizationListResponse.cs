using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayAuthorizationListResponse : IdLink
    {
        public MobilePayAuthorizationListResponse(Uri id, List<MobilePayAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<MobilePayAuthorization> AuthorizationList { get; }
    }
}