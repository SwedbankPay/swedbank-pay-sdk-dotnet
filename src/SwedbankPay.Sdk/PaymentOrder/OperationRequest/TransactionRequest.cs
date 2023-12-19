using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public record TransactionRequest
{
    public string Description { get; }
    public Amount Amount { get; }
    public Amount VatAmount { get; }
    public string PayeeReference { get; }
    public string? ReceiptReference { get; set; }
    public IList<OrderItem> OrderItems { get; }

    public TransactionRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
    {
        Description = description;
        Amount = amount.InLowestMonetaryUnit;
        VatAmount = vatAmount.InLowestMonetaryUnit;
        PayeeReference = payeeReference;
        OrderItems = new List<OrderItem>();
    }
}