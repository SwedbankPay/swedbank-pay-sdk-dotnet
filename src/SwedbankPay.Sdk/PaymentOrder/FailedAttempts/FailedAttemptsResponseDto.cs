namespace SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

internal record FailedAttemptsResponseDto : IdentifiableDto
{
    public IList<FailedAttemptListItemDto>? FailedAttemptList { get; init; }

    public FailedAttemptsResponseDto(string id) : base(id)
    {
    }

    public FailedAttemptsResponse Map()
    {
        return new FailedAttemptsResponse(this);
    }
}