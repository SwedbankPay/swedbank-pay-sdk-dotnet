using SwedbankPay.Sdk.PaymentOrder.Reversed;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;

internal record ReversedResponseDto : IdentifiableDto
{
    public long Number { get; init; }
    public string? Instrument { get; init; }
    public string? PayeeReference { get; init; }
    public long Amount { get; init; }
    public long SubmittedAmount { get; init; }
    public long FeeAmount { get; init; }
    public long DiscountAmount { get; init; }
    public ReversedDetailsDto? Details { get; init; }
    
    public IReversedResponse Map()
    {
        return new ReversedResponse(this);
    } 
}