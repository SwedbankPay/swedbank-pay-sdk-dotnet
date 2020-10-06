using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;
using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentOperations
    {
        Func<PaymentAbortRequest, Task<InvoicePaymentResponse>> Abort { get; }
        Func<InvoiceApprovedLegalAddressRequest, Task<ApprovedLegalAddressResponse>> ApprovedLegalAddress { get; }
        Func<InvoicePaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<InvoicePaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<InvoicePaymentAuthorizationRequest, Task<InvoicePaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<InvoicePaymentReversalRequest, Task<ReversalResponse>> Reversal { get; }
        HttpOperation ViewAuthorization { get; }
    }
}