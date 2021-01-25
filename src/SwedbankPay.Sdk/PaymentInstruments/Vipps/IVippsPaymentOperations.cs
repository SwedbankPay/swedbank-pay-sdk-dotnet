using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Map of all currently available operations in Vipps.
    /// Mapped to a <seealso cref="Func{T, TResult}"/> for your convenience.
    /// </summary>
    public interface IVippsPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Performs a cancellation on the current payment, if available.
        /// </summary>
        Func<VippsPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }

        /// <summary>
        /// Performs a capture on the current payment, if available.
        /// </summary>
        Func<VippsPaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }

        /// <summary>
        /// Does a direct authorization with no user input, if available.
        /// </summary>
        Func<VippsPaymentAuthorizationRequest, Task<IVippsPaymentAuthorizationResponse>> DirectAuthorization { get; }

        /// <summary>
        /// Get the details to redirect the payer to authorize the payment, if available.
        /// </summary>
        HttpOperation RedirectAuthorization { get; }

        /// <summary>
        /// Performs a reversal on the current payment, if available.
        /// </summary>
        Func<VippsPaymentReversalRequest, Task<IReversalResponse>> Reversal { get; }

        /// <summary>
        /// Updates the current payment, if available.
        /// </summary>
        HttpOperation Update { get; }

        /// <summary>
        /// Get the details to open a hosted view authorization frame for the payer, if available.
        /// </summary>
        HttpOperation ViewAuthorization { get; }
    }
}