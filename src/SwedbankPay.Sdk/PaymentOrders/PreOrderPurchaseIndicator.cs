namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
    /// </summary>
    public sealed class PreOrderPurchaseIndicator : TypeSafeEnum<PreOrderPurchaseIndicator, string>
    {
        public static PreOrderPurchaseIndicator MerchandiseAvailable { get; } = new PreOrderPurchaseIndicator(nameof(MerchandiseAvailable), "01");
        public static PreOrderPurchaseIndicator FutureAvailability { get; } = new PreOrderPurchaseIndicator(nameof(FutureAvailability), "02");

        public PreOrderPurchaseIndicator(string name, string value) : base(name, value)
        {
        }
    }
}