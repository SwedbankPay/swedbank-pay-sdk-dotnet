using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// THe entry point for creating and retreving Mobile Pay payments in our API.
    /// </summary>
    public interface IMobilePayResource
    {
        /// <summary>
        /// Creates a new MobilePay payment.
        /// </summary>
        /// <param name="paymentRequest">The details on what the payment is and contains.</param>
        /// <param name="paymentExpand">Flags describing which sub-resources should be automatically expanded and avialable</param>
        /// <returns>A MobilePay payment.</returns>
        Task<IMobilePayPaymentResponse> Create(MobilePayPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        /// <summary>
        /// Gets an already created MobilePay payment.
        /// </summary>
        /// <param name="id">A unique Uri to access a already made MobilePay payment.</param>
        /// <param name="paymentExpand">Flags describing which sub-resources should be automatically expanded and avialable</param>
        /// <returns>A MobilePay payment.</returns>
        Task<IMobilePayPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
