using SwedbankPay.Sdk.PaymentOrder.Reversed;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;

internal record ReversedResponse : Identifiable, IReversedResponse
{
    public long Number { get; }
    public string? Instrument { get; }
    public string? PayeeReference { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IReversedDetails? Details { get; }
    
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