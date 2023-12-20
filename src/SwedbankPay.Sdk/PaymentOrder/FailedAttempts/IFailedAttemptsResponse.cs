namespace SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

public interface IFailedAttemptsResponse
{
    IList<IFailedAttemptListItem>? FailedAttemptList { get; }
}