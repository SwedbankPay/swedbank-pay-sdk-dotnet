using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Performs a abort on the current payment, if available.
        /// </summary>
        Func<PaymentAbortRequest, Task<ITrustlyPayment>> Abort { get; }

        /// <summary>
        /// Performs a cancel on the current payment, if available.
        /// </summary>
        Func<TrustlyPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }

        /// <summary>
        /// Get the details to redirect a payer to perform a sale, if available.
        /// </summary>
        HttpOperation RedirectSale { get; }

        /// <summary>
        /// Performs a reversal on the current payment, if available.
        /// </summary>
        Func<TrustlyPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }

        /// <summary>
        /// Get the details to perform a hosted view payment, if available.
        /// </summary>
        HttpOperation ViewSale { get; }
    }
}