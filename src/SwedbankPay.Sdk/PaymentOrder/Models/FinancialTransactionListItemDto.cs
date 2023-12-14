namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record FinancialTransactionListItemDto
{
    public string Id { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string? Type { get; set; }
    public long Number { get; set; }
    public long Amount { get; set; }
    public long VatAmount { get; set; }
    public string? Description { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }
    public IdentifiableDto? OrderItems { get; set; }

    public FinancialTransactionListItem Map()
    {
        return new FinancialTransactionListItem(this);
    }
}