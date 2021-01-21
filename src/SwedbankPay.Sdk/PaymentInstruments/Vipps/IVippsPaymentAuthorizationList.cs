using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Resource for getting list of all available authorizations on a Vipps payment.
    /// </summary>
    public interface IVippsPaymentAuthorizationList : IIdentifiable
    {
        /// <summary>
        /// List of all available authorizations on this payment.s
        /// </summary>
        IList<IVippsPaymentAuthorization> AuthorizationList { get; }
    }
}