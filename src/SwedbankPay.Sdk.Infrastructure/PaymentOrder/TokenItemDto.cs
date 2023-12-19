using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record TokenItemDto
{
    public string? Type { get; set; }
    public string? Token { get; set; }
    public string? Name { get; set; }
    public string? ExpiryDate { get; set; }

    public ITokenItem Map()
    {
        return new TokenItem(this);
    }
}