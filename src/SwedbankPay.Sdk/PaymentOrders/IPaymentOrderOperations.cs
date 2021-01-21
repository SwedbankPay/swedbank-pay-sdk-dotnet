using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Mapps the currently known operations in payment order to easily
    /// accessable methods.
    /// </summary>
    public interface IPaymentOrderOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Aborts the payment order, if available.
        /// </summary>
        Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse>> Abort { get; }

        /// <summary>
        /// Cancels the payment order, if available.
        /// </summary>
        Func<PaymentOrderCancelRequest, Task<CancellationResponse>> Cancel { get; }

        /// <summary>
        /// Captures the authorized <seealso cref="Sdk.Amount"/> on the payment order, if available.
        /// </summary>
        Func<PaymentOrderCaptureRequest, Task<CaptureResponse>> Capture { get; }

        /// <summary>
        /// Reverses previously captured <seealso cref="Sdk.Amount"/> on the payment order, if available.
        /// </summary>
        Func<PaymentOrderReversalRequest, Task<IReversalResponse>> Reverse { get; }

        /// <summary>
        /// Updates the contents of the payment order, if available.
        /// </summary>
        Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse>> Update { get; }

        /// <summary>
        /// Returns details needed to created a hosted view for the payer to see the payment order, if available.
        /// </summary>
        HttpOperation View { get; }
    }
}