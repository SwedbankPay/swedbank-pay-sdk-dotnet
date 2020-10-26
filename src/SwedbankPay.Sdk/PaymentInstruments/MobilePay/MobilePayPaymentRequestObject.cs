using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentRequestObject
    {
        protected internal MobilePayPaymentRequestObject(Uri shoplogoUrl)
        {
            ShoplogoUrl = shoplogoUrl;
        }

        /// <summary>
        ///    URI to logo that will be visible at MobilePay payment menu
        /// </summary>
        public Uri ShoplogoUrl { get; set; }

    }
}
