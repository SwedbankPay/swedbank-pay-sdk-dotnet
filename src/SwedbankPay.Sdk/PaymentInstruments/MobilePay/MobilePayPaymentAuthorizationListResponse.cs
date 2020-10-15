using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentAuthorizationListResponse : IdLink
    {
        public MobilePayPaymentAuthorizationListResponse(Uri id, List<MobilePayPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<MobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}