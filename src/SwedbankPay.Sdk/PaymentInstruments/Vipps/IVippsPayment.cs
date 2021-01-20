using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Transactional details about a Vipps payment.
    /// </summary>
    public interface IVippsPayment : IIdentifiable, IPaymentInstrument
    {
        /// <summary>
        /// Resrouce to get available authorizations on this payment.
        /// </summary>
        public IVippsPaymentAuthorizationListResponse Authorizations { get; }
    }
}