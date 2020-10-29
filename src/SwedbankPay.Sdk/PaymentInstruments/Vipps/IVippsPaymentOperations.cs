using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<VippsPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<VippsPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<VippsPaymentAuthorizationRequest, Task<VippsPaymentAuthorizationResponse>> DirectAuthorization { get; }
        HttpOperation RedirectAuthorization { get; }
        Func<VippsPaymentReversalRequest, Task<IReversalResponse>> Reversal { get; }
        HttpOperation Update { get; }
        HttpOperation ViewAuthorization { get; }
    }
}