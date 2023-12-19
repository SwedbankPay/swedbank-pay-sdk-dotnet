using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record TokenItemDto
{
    public string? Type { get; init; }
    public string? Token { get; init; }
    public string? Name { get; init; }
    public string? ExpiryDate { get; init; }

    public ITokenItem Map()
    {
        return new TokenItem(this);
    }
}