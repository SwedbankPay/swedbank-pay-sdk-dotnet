using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<IInvoicePaymentResponse>> Abort { get; }
        Func<InvoiceApprovedLegalAddressRequest, Task<ApprovedLegalAddressResponse>> ApprovedLegalAddress { get; }
        Func<InvoicePaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
        Func<InvoicePaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }
        Func<InvoicePaymentAuthorizationRequest, Task<IInvoicePaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<InvoicePaymentReversalRequest, Task<IReversalResponse>> Reversal { get; }
        HttpOperation ViewAuthorization { get; }
    }
}