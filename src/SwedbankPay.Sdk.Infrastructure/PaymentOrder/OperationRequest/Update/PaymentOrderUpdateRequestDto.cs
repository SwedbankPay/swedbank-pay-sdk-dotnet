using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Update;

internal record PaymentOrderUpdateRequestDto
{
    internal PaymentOrderUpdateRequestDto(PaymentOrderUpdateRequest payload)
    {
        PaymentOrder = new PaymentOrderUpdateDto(payload.PaymentOrder);
    }

    public PaymentOrderUpdateDto PaymentOrder { get; }
}