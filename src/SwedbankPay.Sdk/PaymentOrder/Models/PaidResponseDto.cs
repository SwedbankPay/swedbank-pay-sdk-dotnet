namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PaidResponseDto : IdentifiableDto
{
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
    public PaidDetailsDto? Details { get; set; }

    public PaidResponseDto(string id) : base(id)
    {
    }

    public PaidResponse Map()
    {
        return new PaidResponse(this);
    }
}