namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record CancelledDetailsDto
{
    public string? NonPaymentToken { get; set; }
    public string? ExternalNonPaymentToken { get; set; }

    public CancelledDetails Map()
    {
        return new CancelledDetails(this);
    }
}