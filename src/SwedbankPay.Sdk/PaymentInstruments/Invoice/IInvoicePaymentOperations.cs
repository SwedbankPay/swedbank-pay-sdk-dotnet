using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        /// <summary>
        /// Performs a abort on the current payment, if available.
        /// </summary>
        Func<PaymentAbortRequest, Task<IInvoicePaymentResponse>> Abort { get; }

        /// <summary>
        /// Gets the current approved legal address, if available.
        /// </summary>
        Func<InvoiceApprovedLegalAddressRequest, Task<ApprovedLegalAddressResponse>> ApprovedLegalAddress { get; }

        /// <summary>
        /// Performs a cancel on the current payment, if available.
        /// </summary>
        Func<InvoicePaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }

        /// <summary>
        /// Performs a capture on the current payment, if available.
        /// </summary>
        Func<InvoicePaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }

        /// <summary>
        /// Performs a direct authorization on the current payment, if available.
        /// </summary>
        [Obsolete]
        Func<InvoicePaymentAuthorizationRequest, Task<IInvoicePaymentAuthorizationResponse>> DirectAuthorization { get; }

        /// <summary>
        /// Gets the information needed to redirect the authorization, if available.
        /// </summary>
        HttpOperation RedirectAuthorization { get; }

        /// <summary>
        /// Performs a reversal on the current payment, if available.
        /// </summary>
        Func<InvoicePaymentReversalRequest, Task<IReversalResponse>> Reversal { get; }

        /// <summary>
        /// Gets the information needed to view the authorization of the payment, if available.
        /// </summary>
        HttpOperation ViewAuthorization { get; }
    }
}