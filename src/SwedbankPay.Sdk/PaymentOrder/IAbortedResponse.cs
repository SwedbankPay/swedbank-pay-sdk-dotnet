namespace SwedbankPay.Sdk.PaymentOrder;

public interface IAbortedResponse
{
    string? AbortReason { get; }
}