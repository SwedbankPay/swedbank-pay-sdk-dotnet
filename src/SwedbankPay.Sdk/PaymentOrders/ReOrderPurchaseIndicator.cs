namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///  Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
    /// </summary>
    public sealed class ReOrderPurchaseIndicator : TypeSafeEnum<ReOrderPurchaseIndicator, string>
    {
        public static ReOrderPurchaseIndicator MerchandiseAvailable { get; } = new ReOrderPurchaseIndicator(nameof(MerchandiseAvailable), "01");
        public static ReOrderPurchaseIndicator FutureAvailability { get; } = new ReOrderPurchaseIndicator(nameof(FutureAvailability), "02");
        public ReOrderPurchaseIndicator(string name, string value) : base(name, value)
        {
        }
    }
}