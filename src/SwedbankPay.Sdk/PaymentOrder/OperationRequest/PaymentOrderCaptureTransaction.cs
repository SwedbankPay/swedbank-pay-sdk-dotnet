namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

/// <summary>
/// Transactional details for capturing funds for a payment order.
/// </summary>
public record PaymentOrderCaptureTransaction
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderCaptureTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount of funds to capture.</param>
    /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
    /// <param name="description">A textual description of the capture.</param>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    /// <param name="receiptReference"></param>
    protected internal PaymentOrderCaptureTransaction(Amount amount,
        Amount vatAmount,
        string description,
        string payeeReference,
        string receiptReference)
    {
        Amount = amount;
        VatAmount = vatAmount;
        Description = description;
        PayeeReference = payeeReference;
        ReceiptReference = receiptReference;
    }

    public string ReceiptReference { get; set; }

    /// <summary>
    /// The <seealso cref="Sdk.Amount"/> (including VAT, if any) to charge the payer
    /// , entered in the lowest monetary unit of the selected currency. 
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// A human readable description of maximum 40 characters of the transaction.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The array of items being purchased with the order.
    /// Used to print on invoices if the payer chooses to pay with invoice, among other things.
    /// It should only contain the items to be captured from the order.
    /// </summary>
    public IList<OrderItem> OrderItems { get; } = new List<OrderItem>();

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation. 
    /// </summary>
    public string PayeeReference { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
    /// This field is used to specify how much ofthe total amount the VAT will be.
    /// Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    public Amount VatAmount { get; }
}