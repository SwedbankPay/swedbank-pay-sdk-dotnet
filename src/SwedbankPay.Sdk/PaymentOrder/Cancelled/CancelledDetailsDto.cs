namespace SwedbankPay.Sdk.PaymentOrder.Cancelled;

internal record CancelledDetailsDto
{
    public string? NonPaymentToken { get; init; }
    public string? ExternalNonPaymentToken { get; init; }

    public CancelledDetails Map()
    {
        return new CancelledDetails(this);
    }
}