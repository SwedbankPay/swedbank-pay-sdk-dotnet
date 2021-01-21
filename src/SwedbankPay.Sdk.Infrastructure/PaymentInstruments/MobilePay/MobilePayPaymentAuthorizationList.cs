using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationList : Identifiable, IMobilePayPaymentAuthorizationList
    {
        public MobilePayPaymentAuthorizationList(Uri id, List<IMobilePayPaymentAuthorization> authorizationList)
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