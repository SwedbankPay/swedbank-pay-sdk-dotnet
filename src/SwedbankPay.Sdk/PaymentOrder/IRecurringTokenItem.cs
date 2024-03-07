namespace SwedbankPay.Sdk.PaymentOrder;

public interface IRecurringTokenItem
{
    public string? Type { get; }
    public string? Token { get; }
    public string? Name { get; }
    public string? ExpiryDate { get; }
}