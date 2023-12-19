namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Reversal;

public record PaymentOrderReversalRequest
{
    public PaymentOrderReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
    {
        Transaction = new TransactionRequest(amount, vatAmount, description, payeeReference);
    }

    public string ReceiptReference
    {
        set => Transaction.ReceiptReference = value;
    }

    public TransactionRequest Transaction { get; }
}