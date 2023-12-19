namespace SwedbankPay.Sdk.PaymentOrder;

public interface ITokenItem
{
    public string? Type { get; }
    public string? Token { get; }
    public string? Name { get; }
    public string? ExpiryDate { get; }
}