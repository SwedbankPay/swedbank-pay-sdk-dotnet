using SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IFinancialTransactionListItem
{
    public Uri Id { get; }
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
}