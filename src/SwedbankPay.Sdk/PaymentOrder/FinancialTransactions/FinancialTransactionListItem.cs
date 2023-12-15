namespace SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

public record FinancialTransactionListItem : Identifiable
{
    public DateTime Created { get; }
    public DateTime Updated { get; }
    public FinancialTransactionType? Type { get; }
    public long Number { get; }
    public Amount Amount { get; }
    public Amount VatAmount { get; }
    public string? Description { get; }
    public string? PayeeReference { get; }
    public string? ReceiptReference { get; }
    public IIdentifiable? OrderItems { get; }

    internal FinancialTransactionListItem(FinancialTransactionListItemDto dto) : base(dto.Id)
    {
        Created = dto.Created;
        Updated = dto.Updated;
        Type = dto.Type;
        Number = dto.Number;
        Amount = new Amount(dto.Amount);
        VatAmount = new Amount(dto.VatAmount);
        Description = dto.Description;
        PayeeReference = dto.PayeeReference;
        ReceiptReference = dto.ReceiptReference;
        OrderItems = dto.OrderItems != null ? new Identifiable(dto.OrderItems) : null;
    }
}