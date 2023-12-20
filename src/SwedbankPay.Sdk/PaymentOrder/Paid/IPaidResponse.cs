namespace SwedbankPay.Sdk.PaymentOrder.Paid;

public interface IPaidResponse
{
    public string? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public TransactionType? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IList<ITokenItem>? Tokens { get; }
    public IPaidDetails? Details { get; }
}