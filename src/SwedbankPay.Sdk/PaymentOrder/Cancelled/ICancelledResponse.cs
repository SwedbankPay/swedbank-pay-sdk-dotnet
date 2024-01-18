namespace SwedbankPay.Sdk.PaymentOrder.Cancelled;

public interface ICancelledResponse
{
    public Uri Id { get; }
    public string? CancelReason { get; }
    public string? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public string? OrderReference { get; }
    public string? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IList<IRecurringTokenItem>? Tokens { get; }
    public ICancelledDetails? Details { get; }
}