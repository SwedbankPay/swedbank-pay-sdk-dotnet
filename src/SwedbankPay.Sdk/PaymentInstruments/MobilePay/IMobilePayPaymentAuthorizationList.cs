using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object holding currently available authorizations for a payment.
    /// </summary>
    public interface IMobilePayPaymentAuthorizationList
    {
        /// <summary>
        /// The currently available list of authorizations.
        /// </summary>
        IList<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}