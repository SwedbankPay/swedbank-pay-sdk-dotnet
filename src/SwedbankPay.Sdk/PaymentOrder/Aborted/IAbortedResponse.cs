namespace SwedbankPay.Sdk.PaymentOrder.Aborted;

public interface IAbortedResponse
{
    string? AbortReason { get; }
}