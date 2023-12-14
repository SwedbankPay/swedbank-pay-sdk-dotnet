namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

internal record TransactionRequestDto
{
    public TransactionRequestDto(TransactionRequest payload)
    {
        Description = payload.Description;
        Amount = payload.Amount.InLowestMonetaryUnit;
        VatAmount = payload.VatAmount.InLowestMonetaryUnit;
        PayeeReference = payload.PayeeReference;
        ReceiptReference = payload.ReceiptReference;
        OrderItems = payload.OrderItems.Select(x => new OrderItemDto(x)).ToList();
    }
    
    public string Description { get; }
    public long Amount { get; }
    public long VatAmount { get; }
    public string PayeeReference { get; }
    public string? ReceiptReference { get; }
    public IList<OrderItemDto> OrderItems { get; }
}