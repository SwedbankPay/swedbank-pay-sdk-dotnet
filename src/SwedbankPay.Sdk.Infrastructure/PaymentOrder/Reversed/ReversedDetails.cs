using SwedbankPay.Sdk.PaymentOrder.Reversed;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;

internal record ReversedDetails : IReversedDetails
{
    public string? Msisdn { get; init; }
}