using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Reversal;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Reversal;

internal record PaymentOrderReversalRequestDto
{
    internal PaymentOrderReversalRequestDto(PaymentOrderReversalRequest payload)
    {
        Transaction = new PaymentOrderReversalTransactionDto(payload.Transaction);
    }

    public PaymentOrderReversalTransactionDto Transaction { get; }
}