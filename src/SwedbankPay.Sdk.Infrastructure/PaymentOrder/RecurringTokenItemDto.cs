using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record RecurringTokenItemDto
{
    public string? Type { get; init; }
    public string? Token { get; init; }
    public string? Name { get; init; }
    public string? ExpiryDate { get; init; }

    public IRecurringTokenItem Map()
    {
        return new RecurringTokenItem(this);
    }
}