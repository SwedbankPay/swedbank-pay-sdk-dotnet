namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

internal record PaymentOrderCancelRequestDto
{
    public PaymentOrderCancelRequestDetailDto Transaction { get; }

    public PaymentOrderCancelRequestDto(PaymentOrderCancelRequest payload)
    {
        Transaction = new PaymentOrderCancelRequestDetailDto(payload.Transaction);
    }
}