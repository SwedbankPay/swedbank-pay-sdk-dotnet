namespace SwedbankPay.Sdk.PaymentOrder.Reversed;

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
    
    public ReversedResponse Map()
    {
        return new ReversedResponse(this);
    } 
}