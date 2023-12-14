namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PaidResponseDto : IdentifiableDto
{
    public string? Instrument { get; init; }
    public long Number { get; init; }
    public string? PayeeReference { get; init; }
    public string? OrderReference { get; init; }
    public string? TransactionType { get; init; }
    public long Amount { get; init; }
    public long SubmittedAmount { get; init; }
    public long FeeAmount { get; init; }
    public long DiscountAmount { get; init; }
    public IList<TokenItemDto>? Tokens { get; init; }
    public PaidDetailsDto? Details { get; init; }

    public PaidResponseDto(string id) : base(id)
    {
    }

    public PaidResponse Map()
    {
        return new PaidResponse(this);
    }
}