namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates the merchandise delivery timeframe.
    /// </summary>
    public sealed class DeliveryTimeFrameIndicator : TypeSafeEnum<DeliveryTimeFrameIndicator, string>
    {
        public static DeliveryTimeFrameIndicator ElectronicDelivery { get; } = new DeliveryTimeFrameIndicator(nameof(ElectronicDelivery), "01");
        public static DeliveryTimeFrameIndicator SameDayShipping { get; } = new DeliveryTimeFrameIndicator(nameof(SameDayShipping), "02");
        public static DeliveryTimeFrameIndicator OverNightShipping { get; } = new DeliveryTimeFrameIndicator(nameof(OverNightShipping), "03");
        public static DeliveryTimeFrameIndicator TwoDayOrMoreShipping { get; } = new DeliveryTimeFrameIndicator(nameof(TwoDayOrMoreShipping), "04");
        public DeliveryTimeFrameIndicator(string name, string value) : base(name, value)
        {
        }
    }
}