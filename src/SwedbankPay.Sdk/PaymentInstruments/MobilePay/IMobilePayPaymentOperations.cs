using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public interface IMobilePayPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<IMobilePayPaymentResponse>> Abort { get; }
        Func<MobilePayPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<MobilePayPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<MobilePayPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        HttpOperation ViewAuthorization { get; }
    }
}