using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationListResponse : Identifiable, IMobilePayPaymentAuthorizationListResponse
    {
        public MobilePayPaymentAuthorizationListResponse(Uri id, List<IMobilePayPaymentAuthorization> authorizationList)
            : base(id)
        {
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// A list of authorizations available on the current payment.
        /// </summary>
        public IList<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}