namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Reversal;

internal record PaymentOrderReversalRequestDto
{
    internal PaymentOrderReversalRequestDto(PaymentOrderReversalRequest payload)
    {
        Transaction = payload.Transaction.Map();
    }

    public TransactionRequestDto Transaction { get; }
}