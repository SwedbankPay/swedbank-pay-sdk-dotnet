using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.FailedAttempts;

internal record FailedAttemptListItemDto
{
    public DateTime Created { get; init; }
    public string? Instrument { get; init; }
    public long Number { get; init; }
    public string Status { get; init; } = null!;
    public ProblemDto? Problem { get; init; }

    public IFailedAttemptListItem Map()
    {
        return new FailedAttemptListItem(this);
    }
}