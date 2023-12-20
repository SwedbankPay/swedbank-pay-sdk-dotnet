using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Capture;

internal record PaymentOrderCaptureRequestDto
{
    internal PaymentOrderCaptureRequestDto(PaymentOrderCaptureRequest payload)
    {
        Transaction = new PaymentOrderCaptureTransactionDto(payload.Transaction);
    }
    
    public PaymentOrderCaptureTransactionDto Transaction { get; }
}