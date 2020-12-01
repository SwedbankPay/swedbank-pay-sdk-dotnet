using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object holding currently available authorizations for a payment.
    /// </summary>
    public interface IMobilePayPaymentAuthorizationListResponse
    {
        /// <summary>
        /// The currently available list of authorizations.
        /// </summary>
        public List<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}