namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;

/// <summary>
/// API request object for capturing funds for a payment order.
/// </summary>
public record PaymentOrderCaptureRequest
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderCaptureRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount of funds to capture.</param>
    /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
    /// <param name="description">A textual description of the capture.</param>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    public PaymentOrderCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
    {
        Transaction = new PaymentOrderCaptureTransaction(amount, vatAmount, description, payeeReference);
    }

    /// <summary>
    /// A unique reference to the transaction, provided by the merchant. Can be used as an invoice or receipt number as a supplement to payeeReference.
    /// </summary>
    public string? ReceiptReference
    {
        set => Transaction.ReceiptReference = value;
        get => Transaction.ReceiptReference;
    }
    
    /// <summary>
    /// Transactional details about the capture of the current payment order.
    /// </summary>
    public PaymentOrderCaptureTransaction Transaction { get; }
}