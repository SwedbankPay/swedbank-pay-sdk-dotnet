namespace SwedbankPay.Sdk.PaymentOrder;

public interface ICancelledDetails
{
    string? NonPaymentToken { get; }
    string? ExternalNonPaymentToken { get; }
}