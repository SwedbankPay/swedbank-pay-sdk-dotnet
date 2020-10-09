namespace SwedbankPay.Sdk.Payments
{
    public interface IPrice
    {
        Amount Amount { get; }
        PriceType Type { get; }
        Amount VatAmount { get; }
    }
}