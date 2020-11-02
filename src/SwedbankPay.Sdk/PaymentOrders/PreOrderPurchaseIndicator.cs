namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
    /// </summary>
    public sealed class PreOrderPurchaseIndicator : TypeSafeEnum<PreOrderPurchaseIndicator>
    {
        public static readonly PreOrderPurchaseIndicator MerchandiseAvailable =
            new PreOrderPurchaseIndicator(nameof(MerchandiseAvailable), "01");

        public static readonly PreOrderPurchaseIndicator FutureAvailability =
            new PreOrderPurchaseIndicator(nameof(FutureAvailability), "02");


        public PreOrderPurchaseIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}