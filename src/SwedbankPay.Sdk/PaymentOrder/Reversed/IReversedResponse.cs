namespace SwedbankPay.Sdk.PaymentOrder.Reversed;

public interface IReversedResponse
{
    public long Number { get; }
    public string? Instrument { get; }
    public string? PayeeReference { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IReversedDetails? Details { get; }   
}