namespace SwedbankPay.Sdk.PaymentOrder;

internal record TokenItemDto
{
    public string? Type { get; set; }
    public string? Token { get; set; }
    public string? Name { get; set; }
    public string? ExpiryDate { get; set; }

    public TokenItem Map()
    {
        return new TokenItem(this);
    }
}