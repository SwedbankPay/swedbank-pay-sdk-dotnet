using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
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