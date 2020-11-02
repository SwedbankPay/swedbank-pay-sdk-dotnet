using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<IMobilePayPaymentResponse>> Abort { get; }
        Func<MobilePayPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
        Func<MobilePayPaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<MobilePayPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
        HttpOperation ViewAuthorization { get; }
    }
}