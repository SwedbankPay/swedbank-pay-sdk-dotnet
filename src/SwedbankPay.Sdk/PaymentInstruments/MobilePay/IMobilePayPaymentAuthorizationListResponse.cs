using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentAuthorizationListResponse
    {
        /// <summary>
        /// The currently available list of authorizations.
        /// </summary>
        public List<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}