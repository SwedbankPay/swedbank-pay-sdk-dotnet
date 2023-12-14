namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record ReversedResponse : Identifiable
{
    public long Number { get; set; }
    public string? Instrument { get; set; }
    public string? PayeeReference { get; set; }
    public Amount Amount { get; set; }
    public Amount SubmittedAmount { get; set; }
    public Amount FeeAmount { get; set; }
    public Amount DiscountAmount { get; set; }
    public ReversedDetails? Details { get; set; }
    
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