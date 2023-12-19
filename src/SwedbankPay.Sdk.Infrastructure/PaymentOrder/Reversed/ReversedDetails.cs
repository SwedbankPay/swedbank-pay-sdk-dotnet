using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;

internal record ReversedDetails : IReversedDetails
{
    public string? Msisdn { get; init; }
}