using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Aborts the current payment if available.
        /// </summary>
        Func<CardPaymentAbortRequest, Task<ICardPaymentResponse>> Abort { get; }

        /// <summary>
        /// Cancels the current payment if available.
        /// </summary>
        Func<CardPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }

        /// <summary>
        /// Captures the current payment if available.
        /// </summary>
        Func<CardPaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }

        /// <summary>
        /// Does a direct authorization of this payment if available.
        /// Requires that you are compliant with PCI-DSS regulations.
        /// </summary>
        Func<CardPaymentAuthorizationRequest, Task<ICardPaymentAuthorizationResponse>> DirectAuthorization { get; }

        /// <summary>
        /// Does a direct verification of this payment if available.
        /// </summary>
        HttpOperation DirectVerification { get; }

        /// <summary>
        /// Returns the information about a payment that has the <see cref="State.Paid"/>.
        /// </summary>
        HttpOperation PaidPayment { get; }

        /// <summary>
        /// Get the <see cref="HttpOperation"/> to redirect a payer to the authorization frame if available.
        /// </summary>
        HttpOperation RedirectAuthorization { get; }

        /// <summary>
        /// Get the <see cref="HttpOperation"/> to redirect a payer to the verification frame if available.
        /// </summary>
        HttpOperation RedirectVerification { get; }

        /// <summary>
        /// Reverse a payment if available.
        /// </summary>
        Func<CardPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }

        /// <summary>
        /// View the authorization if available.
        /// </summary>
        HttpOperation ViewAuthorization { get; }

        /// <summary>
        /// View the verification if available.
        /// </summary>
        HttpOperation ViewVerification { get; }
    }
}