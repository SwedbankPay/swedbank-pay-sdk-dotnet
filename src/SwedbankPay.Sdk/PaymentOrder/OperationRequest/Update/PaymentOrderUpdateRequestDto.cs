namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;

internal record PaymentOrderUpdateRequestDto
{
    internal PaymentOrderUpdateRequestDto(PaymentOrderUpdateRequest payload)
    {
        PaymentOrder = new PaymentOrderUpdateDto(payload.PaymentOrder);
    }

    public PaymentOrderUpdateDto PaymentOrder { get; }
}