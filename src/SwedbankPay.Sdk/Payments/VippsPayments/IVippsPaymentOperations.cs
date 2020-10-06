using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public interface IVippsPaymentOperations
    {
        Func<VippsPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<VippsPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<VippsPaymentAuthorizationRequest, Task<VippsPaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<VippsPaymentReversalRequest, Task<ReversalResponse>> Reversal { get; }
        HttpOperation Update { get; }
        HttpOperation ViewAuthorization { get; }
    }
}