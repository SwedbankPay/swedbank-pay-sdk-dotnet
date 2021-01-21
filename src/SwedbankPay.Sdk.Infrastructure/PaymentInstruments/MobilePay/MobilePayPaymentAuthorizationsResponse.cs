using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationsResponse
    {
        public MobilePayPaymentAuthorizationsResponse(Uri payment, MobilePayPaymentAuthorizationList authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// A <seealso cref="Uri"/> point to the current payment.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// A list of currently available authorizations on this payment.
        /// </summary>
        public MobilePayPaymentAuthorizationList AuthorizationList { get; }
    }
}
