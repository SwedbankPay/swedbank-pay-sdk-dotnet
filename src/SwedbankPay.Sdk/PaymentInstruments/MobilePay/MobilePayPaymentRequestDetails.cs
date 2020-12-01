using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object containing custom information for the Mobile Pay payment window.
    /// </summary>
    public class MobilePayPaymentRequestDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="MobilePayPaymentRequestDetails"/> with the provided <paramref name="shoplogoUrl"/>.
        /// </summary>
        /// <param name="shoplogoUrl">A custom logo to use in the payment window, must use HTTPS.</param>
        protected internal MobilePayPaymentRequestDetails(Uri shoplogoUrl)
        {
            ShoplogoUrl = shoplogoUrl;
        }

        /// <summary>
        ///    URI to logo that will be visible at MobilePay payment menu
        /// </summary>
        public Uri ShoplogoUrl { get; set; }

    }
}
