using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Cancel;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Cancel;

internal record PaymentOrderCancelRequestDto
{
    public PaymentOrderCancelRequestDetailDto Transaction { get; }

    internal PaymentOrderCancelRequestDto(PaymentOrderCancelRequest payload)
    {
        Transaction = new PaymentOrderCancelRequestDetailDto(payload.Transaction);
    }
}