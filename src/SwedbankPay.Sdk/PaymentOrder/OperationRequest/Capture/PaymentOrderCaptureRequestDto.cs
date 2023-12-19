namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;

internal record PaymentOrderCaptureRequestDto
{
    public PaymentOrderCaptureTransactionDto Transaction { get; }

    internal PaymentOrderCaptureRequestDto(PaymentOrderCaptureRequest payload)
    {
        Transaction = new PaymentOrderCaptureTransactionDto(payload.Transaction);
    }
}