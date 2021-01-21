using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationList : Identifiable, IVippsPaymentAuthorizationList
    {
        public VippsPaymentAuthorizationList(Uri id, List<IVippsPaymentAuthorization> authorizationList)
            : base(id)
        {
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// List of all currently available authorizations for this payment.
        /// </summary>
        public IList<IVippsPaymentAuthorization> AuthorizationList { get; }
    }
}