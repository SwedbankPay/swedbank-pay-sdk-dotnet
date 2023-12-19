using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Cancelled;

internal record CancelledDetailsDto
{
    public string? NonPaymentToken { get; init; }
    public string? ExternalNonPaymentToken { get; init; }

    public ICancelledDetails Map()
    {
        return new CancelledDetails(this);
    }
}