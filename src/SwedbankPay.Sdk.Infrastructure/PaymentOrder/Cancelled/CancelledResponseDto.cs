using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Cancelled;

internal record CancelledResponseDto : IdentifiableDto
{
    public string? CancelReason { get; init; }
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
    public CancelledDetailsDto? Details { get; init; }

    public CancelledResponseDto(string id) : base(id)
    {
    }

    public ICancelledResponse Map()
    {
        return new CancelledResponse(this);
    }
}