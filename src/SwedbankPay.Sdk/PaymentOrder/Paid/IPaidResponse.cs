namespace SwedbankPay.Sdk.PaymentOrder.Paid;

public interface IPaidResponse
{
    public PaymentInstrument? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public TransactionType? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public bool PaymentTokenGenerated { get; }
    public IList<IRecurringTokenItem>? Tokens { get; }
    public IPaidDetails? Details { get; }
}