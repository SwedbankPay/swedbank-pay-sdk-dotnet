using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Aborts the current payment, if available.
        /// </summary>
        Func<PaymentAbortRequest, Task<IMobilePayPaymentResponse>> Abort { get; }

        /// <summary>
        /// Cancels the current payment, if available.
        /// </summary>
        Func<MobilePayPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }

        /// <summary>
        /// Captures the current payment, if available.
        /// </summary>
        Func<MobilePayPaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }

        /// <summary>
        /// Details on where to redirect the payer to authorize the current payment, if available.
        /// </summary>
        HttpOperation RedirectAuthorization { get; }

        /// <summary>
        /// Reverses the current payment, if available.
        /// </summary>
        Func<MobilePayPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }

        /// <summary>
        /// Details on how to view the authorization of the current payment, if available.
        /// </summary>
        HttpOperation ViewAuthorization { get; }
    }
}