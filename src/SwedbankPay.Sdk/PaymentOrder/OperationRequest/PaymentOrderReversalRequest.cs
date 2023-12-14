namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public class PaymentOrderReversalRequest
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