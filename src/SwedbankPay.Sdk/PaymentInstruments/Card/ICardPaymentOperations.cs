using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentOperations : IDictionary<LinkRelation, HttpOperation>
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