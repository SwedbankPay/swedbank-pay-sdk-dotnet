namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

internal record PaymentOrderCaptureRequestDto
{
    public PaymentOrderCaptureTransactionDto Transaction { get; }

    public PaymentOrderCaptureRequestDto(PaymentOrderCaptureRequest payload)
    {
        Transaction = new PaymentOrderCaptureTransactionDto(payload.Transaction);
    }
}