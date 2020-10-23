using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentAuthorizationListResponse : IdLink, IMobilePayPaymentAuthorizationListResponse
    {
        public MobilePayPaymentAuthorizationListResponse(Uri id, List<IMobilePayPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}