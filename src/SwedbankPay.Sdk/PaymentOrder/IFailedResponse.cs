namespace SwedbankPay.Sdk.PaymentOrder;

public interface IFailedResponse
{
    IProblem? Problem { get; }
}