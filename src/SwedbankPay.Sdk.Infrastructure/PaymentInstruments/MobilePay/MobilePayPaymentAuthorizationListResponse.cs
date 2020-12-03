using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationListResponse : Identifiable, IMobilePayPaymentAuthorizationListResponse
    {
        public MobilePayPaymentAuthorizationListResponse(Uri id, List<IMobilePayPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// A list of authorizations available on the current payment.
        /// </summary>
        public List<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}