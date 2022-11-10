namespace SwedbankPay.Sdk.PaymentInstruments;

public class Price : IPrice
{
    public Price(Amount amount, PriceType type, Amount vatAmount)
    {
        Amount = amount;
        Type = type;
        VatAmount = vatAmount;
    }


    public Amount Amount { get; }
    public PriceType Type { get; }
    public Amount VatAmount { get; }
}