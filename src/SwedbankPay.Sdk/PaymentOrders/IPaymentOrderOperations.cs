using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrderOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<Task<IPaymentOrderResponse>> Abort { get; }
        Func<PaymentOrderCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<PaymentOrderCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<PaymentOrderReversalRequest, Task<IReversalResponse>> Reverse { get; }
        Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse>> Update { get; }
        HttpOperation View { get; }
    }
}