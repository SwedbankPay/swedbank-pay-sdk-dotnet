using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Cancelled;

public record CancelledDetails : ICancelledDetails
{
    public string? NonPaymentToken { get; }
    public string? ExternalNonPaymentToken { get; }

    internal CancelledDetails(CancelledDetailsDto dto)
    {
        NonPaymentToken = dto.NonPaymentToken;
        ExternalNonPaymentToken = dto.ExternalNonPaymentToken;
    }
}