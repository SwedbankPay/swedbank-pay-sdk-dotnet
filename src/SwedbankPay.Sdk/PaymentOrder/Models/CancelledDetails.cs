namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record CancelledDetails
{
    public string? NonPaymentToken { get; }
    public string? ExternalNonPaymentToken { get; }

    internal CancelledDetails(CancelledDetailsDto dto)
    {
        NonPaymentToken = dto.NonPaymentToken;
        ExternalNonPaymentToken = dto.ExternalNonPaymentToken;
    }
}