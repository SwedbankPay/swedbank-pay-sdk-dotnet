namespace SwedbankPay.Sdk.PaymentOrder.Reversed;

public record ReversedResponse : Identifiable
{
    public long Number { get; }
    public string? Instrument { get; }
    public string? PayeeReference { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public ReversedDetails? Details { get; }
    
    internal ReversedResponse(ReversedResponseDto dto) : base(dto)
    {
        Number = dto.Number;
        Instrument = dto.Instrument;
        PayeeReference = dto.PayeeReference;
        Amount = dto.Amount;
        SubmittedAmount = dto.SubmittedAmount;
        FeeAmount = dto.FeeAmount;
        DiscountAmount = dto.DiscountAmount;
        Details = dto.Details?.Map();
    }
}