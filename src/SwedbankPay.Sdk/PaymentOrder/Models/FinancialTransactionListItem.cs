namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class FinancialTransactionListItem : Identifiable
{
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public FinancialTransactionType? Type { get; set; }
    public long Number { get; set; }
    public Amount Amount { get; set; }
    public Amount VatAmount { get; set; }
    public string? Description { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }
    public IIdentifiable? OrderItems { get; set; }

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