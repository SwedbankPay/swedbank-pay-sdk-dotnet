namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record CancelledDetailsDto
{
    public string? NonPaymentToken { get; init; }
    public string? ExternalNonPaymentToken { get; init; }

    public CancelledDetails Map()
    {
        return new CancelledDetails(this);
    }
}