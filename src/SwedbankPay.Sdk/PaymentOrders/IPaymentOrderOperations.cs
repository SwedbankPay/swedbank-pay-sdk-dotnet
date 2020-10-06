using SwedbankPay.Sdk.Payments;
using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrderOperations
    {
        Func<Task<PaymentOrderResponse>> Abort { get; }
        Func<PaymentOrderCancelRequest, Task<CancellationResponse>> Cancel { get; }
        Func<PaymentOrderCaptureRequest, Task<CaptureResponse>> Capture { get; }
        Func<PaymentOrderReversalRequest, Task<ReversalResponse>> Reverse { get; }
        Func<PaymentOrderUpdateRequest, Task<PaymentOrderResponse>> Update { get; }
        HttpOperation View { get; }
    }
}