namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
    /// </summary>
    public sealed class ReOrderPurchaseIndicator : TypeSafeEnum<ReOrderPurchaseIndicator>
    {
        public static readonly ReOrderPurchaseIndicator MerchandiseAvailable =
            new ReOrderPurchaseIndicator(nameof(MerchandiseAvailable), "01");

        public static readonly ReOrderPurchaseIndicator FutureAvailability = new ReOrderPurchaseIndicator(nameof(FutureAvailability), "02");


        public ReOrderPurchaseIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}