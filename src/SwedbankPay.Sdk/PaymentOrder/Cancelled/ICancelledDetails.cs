namespace SwedbankPay.Sdk.PaymentOrder.Cancelled;

public interface ICancelledDetails
{
    string? NonPaymentToken { get; }
    string? ExternalNonPaymentToken { get; }
}