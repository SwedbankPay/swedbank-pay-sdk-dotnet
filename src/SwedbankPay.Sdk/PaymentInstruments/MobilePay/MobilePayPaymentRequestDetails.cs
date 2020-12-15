using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object containing custom information for the Mobile Pay payment window.
    /// </summary>
    public class MobilePayPaymentRequestDetails
    {
        /// <summary>
        ///    URI to logo that will be visible at MobilePay payment menu
        /// </summary>
        public Uri ShoplogoUrl { get; set; }

    }
}
