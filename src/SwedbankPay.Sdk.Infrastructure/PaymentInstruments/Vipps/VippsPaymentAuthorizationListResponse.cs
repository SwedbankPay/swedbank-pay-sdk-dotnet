using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationListResponse : Identifiable, IVippsPaymentAuthorizationListResponse
    {
        public VippsPaymentAuthorizationListResponse(Uri id, List<IVippsPaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// List of all currently available authorizations for this payment.
        /// </summary>
        public List<IVippsPaymentAuthorization> AuthorizationList { get; }
    }
}