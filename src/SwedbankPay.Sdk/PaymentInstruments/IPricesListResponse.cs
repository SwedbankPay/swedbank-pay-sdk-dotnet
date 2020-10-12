namespace SwedbankPay.Sdk.Payments
{
    public interface IPricesListResponse
    {
        System.Collections.Generic.List<Price> PriceList { get; }
    }
}