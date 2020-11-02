using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<CardPaymentAbortRequest, Task<ICardPaymentResponse>> Abort { get; }
        Func<CardPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
        Func<CardPaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }
        Func<CardPaymentAuthorizationRequest, Task<CardPaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation DirectVerification { get; }
        HttpOperation PaidPayment { get; }
        HttpOperation RedirectAuthorization { get; }
        HttpOperation RedirectVerification { get; }
        Func<CardPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
        HttpOperation ViewAuthorization { get; }
        HttpOperation ViewVerification { get; }
    }
}