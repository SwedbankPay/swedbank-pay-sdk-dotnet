using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<IInvoicePaymentResponse>> Abort { get; }
        Func<InvoiceApprovedLegalAddressRequest, Task<ApprovedLegalAddressResponse>> ApprovedLegalAddress { get; }
        Func<InvoicePaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<InvoicePaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<InvoicePaymentAuthorizationRequest, Task<IInvoicePaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<InvoicePaymentReversalRequest, Task<ReversalResponse>> Reversal { get; }
        HttpOperation ViewAuthorization { get; }
    }
}