namespace SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

internal record FinancialTransactionListItemDto
{
    public string Id { get; init; } = null!;
    public DateTime Created { get; init; }
    public DateTime Updated { get; init; }
    public string? Type { get; init; }
    public long Number { get; init; }
    public long Amount { get; init; }
    public long VatAmount { get; init; }
    public string? Description { get; init; }
    public string? PayeeReference { get; init; }
    public string? ReceiptReference { get; init; }
    public IdentifiableDto? OrderItems { get; init; }

    public FinancialTransactionListItem Map()
    {
        return new FinancialTransactionListItem(this);
    }
}