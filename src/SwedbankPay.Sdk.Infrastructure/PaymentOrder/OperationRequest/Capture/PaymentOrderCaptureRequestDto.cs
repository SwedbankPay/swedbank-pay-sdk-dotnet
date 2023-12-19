using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Capture;

internal record PaymentOrderCaptureRequestDto
{
    public PaymentOrderCaptureTransactionDto Transaction { get; }

    internal PaymentOrderCaptureRequestDto(PaymentOrderCaptureRequest payload)
    {
        Transaction = new PaymentOrderCaptureTransactionDto(payload.Transaction);
    }
}