using SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IFailedAttemptListItem
{
    public DateTime Created { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public FailedStatus? Status { get; set; }
    public IProblem? Problem { get; set; }
}