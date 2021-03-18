using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationResponse : IVippsPaymentAuthorizationResponse
    {
        public VippsPaymentAuthorizationResponse(Uri payment, IVippsPaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this payment authorization.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// If available holds all current detail about the payment authorization.
        /// </summary>
        public IVippsPaymentAuthorization Authorization { get; }

    }
}