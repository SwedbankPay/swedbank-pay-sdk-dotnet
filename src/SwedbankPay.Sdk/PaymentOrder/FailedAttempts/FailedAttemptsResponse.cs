namespace SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

public record FailedAttemptsResponse : Identifiable
{
    public IList<FailedAttemptListItem>? FailedAttemptList { get; }

    internal FailedAttemptsResponse(FailedAttemptsResponseDto dto) : base(dto.Id)
    {
        FailedAttemptList = dto.FailedAttemptList?.Select(x => x.Map()).ToList();
    }
}