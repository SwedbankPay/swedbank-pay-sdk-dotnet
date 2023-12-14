namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record FailedAttemptListItemDto
{
    public DateTime Created { get; init; }
    public string? Instrument { get; init; }
    public long Number { get; init; }
    public string Status { get; init; } = null!;
    public ProblemDto? Problem { get; init; }

    public FailedAttemptListItem Map()
    {
        return new FailedAttemptListItem(this);
    }
}