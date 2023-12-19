using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.FailedAttempts;

internal record FailedAttemptsResponseDto : IdentifiableDto
{
    public IList<FailedAttemptListItemDto>? FailedAttemptList { get; init; }

    public FailedAttemptsResponseDto(string id) : base(id)
    {
    }

    public IFailedAttemptsResponse Map()
    {
        return new FailedAttemptsResponse(this);
    }
}