namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

internal record PaymentOrderReversalRequestDto
{
    public PaymentOrderReversalRequestDto(PaymentOrderReversalRequest payload)
    {
        Transaction = payload.Transaction.Map();
    }

    public TransactionRequestDto Transaction { get; }
}