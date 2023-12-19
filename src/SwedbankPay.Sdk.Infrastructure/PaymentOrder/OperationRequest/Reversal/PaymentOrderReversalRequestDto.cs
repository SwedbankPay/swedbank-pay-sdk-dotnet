using SwedbankPay.Sdk.PaymentOrder.OperationRequest;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Reversal;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Reversal;

internal record PaymentOrderReversalRequestDto
{
    internal PaymentOrderReversalRequestDto(PaymentOrderReversalRequest payload)
    {
        Transaction = new TransactionRequestDto(payload.Transaction);
    }

    public TransactionRequestDto Transaction { get; }
}