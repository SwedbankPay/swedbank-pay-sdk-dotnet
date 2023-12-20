using SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.FailedAttempts;

internal record FailedAttemptListItem : IFailedAttemptListItem
{
    public DateTime Created { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public FailedStatus? Status { get; set; }
    public IProblem? Problem { get; set; }

    internal FailedAttemptListItem(FailedAttemptListItemDto dto)
    {
        Created = dto.Created;
        Instrument = dto.Instrument;
        Number = dto.Number;
        Status = dto.Status;
        Problem = dto.Problem?.Map();
    }
}