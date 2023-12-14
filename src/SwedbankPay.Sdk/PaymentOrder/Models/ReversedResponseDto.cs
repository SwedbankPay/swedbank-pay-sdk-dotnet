namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record ReversedResponseDto : IdentifiableDto
{
    public long Number { get; set; }
    public string? Instrument { get; set; }
    public string? PayeeReference { get; set; }
    public long Amount { get; set; }
    public long SubmittedAmount { get; set; }
    public long FeeAmount { get; set; }
    public long DiscountAmount { get; set; }
    public ReversedDetailsDto? Details { get; set; }
    
    public ReversedResponse Map()
    {
        return new ReversedResponse(this);
    } 
}