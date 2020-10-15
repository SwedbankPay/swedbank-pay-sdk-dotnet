namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IPrice
    {
        Amount Amount { get; }
        PriceType Type { get; }
        Amount VatAmount { get; }
    }
}