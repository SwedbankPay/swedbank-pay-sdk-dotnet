using SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.FailedAttempts;

internal record FailedAttemptsResponse : Identifiable, IFailedAttemptsResponse
{
    public IList<IFailedAttemptListItem>? FailedAttemptList { get; }

    internal FailedAttemptsResponse(FailedAttemptsResponseDto dto) : base(dto.Id)
    {
        FailedAttemptList = dto.FailedAttemptList?.Select(x => x.Map()).ToList();
    }
}