namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record CancelledResponseDto : IdentifiableDto
{
    public string? CancelReason { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? PayeeReference { get; set; }
    public string? OrderReference { get; set; }
    public string? TransactionType { get; set; }
    public long Amount { get; set; }
    public long SubmittedAmount { get; set; }
    public long FeeAmount { get; set; }
    public long DiscountAmount { get; set; }
    public IList<TokenItemDto>? Tokens { get; set; }
    public CancelledDetailsDto? Details { get; set; }

    public CancelledResponseDto(string id) : base(id)
    {
    }

    public CancelledResponse Map()
    {
        return new CancelledResponse(this);
    }
}