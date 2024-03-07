using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Reversal;

/// <summary>
/// Transactional details for reversing funds for a payment order.
/// </summary>
public record PaymentOrderReversalTransaction
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderReversalTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount of funds to capture.</param>
    /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
    /// <param name="description">A textual description of the reversal.</param>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    public PaymentOrderReversalTransaction(Amount amount, 
        Amount vatAmount, 
        string description, 
        string payeeReference)
    {
        Amount = amount;
        VatAmount = vatAmount;
        PayeeReference = payeeReference;
        Description = description;
        OrderItems = new List<OrderItem>();
    }
    
    /// <summary>
    /// The transaction amount (including VAT, if any) 
    /// </summary>
    public Amount Amount { get; }
    
    /// <summary>
    /// The payment’s VAT 
    /// </summary>
    public Amount VatAmount { get; }
    
    /// <summary>
    /// A unique reference from the merchant system. Set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }
    
    /// <summary>
    /// A unique reference to the transaction, provided by the merchant. Can be used as an invoice or receipt number as a supplement to payeeReference.
    /// </summary>
    public string? ReceiptReference { get; set; }
    
    /// <summary>
    /// Textual description of why the transaction is reversed.
    /// </summary>
    public string Description { get; }
    
    /// <summary>
    /// The array of items being purchased with the order.
    /// </summary>
    public IList<OrderItem> OrderItems { get; }
}