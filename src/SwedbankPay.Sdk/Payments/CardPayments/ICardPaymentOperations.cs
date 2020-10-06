using SwedbankPay.Sdk.Payments.CardPayments;
using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public interface ICardPaymentOperations
    {
        Func<CardPaymentAbortRequest, Task<CardPaymentResponse>> Abort { get; }
        Func<CardPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<CardPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<CardPaymentAuthorizationRequest, Task<CardPaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation DirectVerification { get; }
        HttpOperation PaidPayment { get; }
        HttpOperation RedirectAuthorization { get; }
        HttpOperation RedirectVerification { get; }
        Func<CardPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        HttpOperation ViewAuthorization { get; }
        HttpOperation ViewVerification { get; }
    }
}