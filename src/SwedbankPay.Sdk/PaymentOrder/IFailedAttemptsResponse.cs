namespace SwedbankPay.Sdk.PaymentOrder;

public interface IFailedAttemptsResponse
{
    IList<IFailedAttemptListItem>? FailedAttemptList { get; }
}