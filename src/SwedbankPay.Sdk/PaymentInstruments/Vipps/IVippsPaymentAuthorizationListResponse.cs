using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Resource for getting list of all available authorizations on a Vipps payment.
    /// </summary>
    public interface IVippsPaymentAuthorizationListResponse
    {
        /// <summary>
        /// The unique <seealso cref="Uri"/> or this authorization list.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// List of all available authorizations on this payment.s
        /// </summary>
        public List<IVippsPaymentAuthorization> AuthorizationList { get; }
    }
}