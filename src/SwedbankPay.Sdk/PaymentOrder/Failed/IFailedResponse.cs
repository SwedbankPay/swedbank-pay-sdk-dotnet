namespace SwedbankPay.Sdk.PaymentOrder.Failed;

public interface IFailedResponse
{
    IProblem? Problem { get; }
}