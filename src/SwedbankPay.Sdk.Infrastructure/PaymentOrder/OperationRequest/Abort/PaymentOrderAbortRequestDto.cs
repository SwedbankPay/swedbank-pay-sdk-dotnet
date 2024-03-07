using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Abort;

internal record PaymentOrderAbortRequestDto
{
    internal PaymentOrderAbortRequestDto(PaymentOrderAbortRequest payload)
    {
        PaymentOrder = new PaymentOrderAbortRequestDetailDto(payload.PaymentOrder);
    }

    public PaymentOrderAbortRequestDetailDto PaymentOrder { get; }
}