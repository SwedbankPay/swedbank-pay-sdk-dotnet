namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     Indicates the merchandise delivery timeframe.
    /// </summary>
    public sealed class DeliveryTimeFrameIndicator : TypeSafeEnum<DeliveryTimeFrameIndicator, string>
    {
        public static readonly DeliveryTimeFrameIndicator ElectronicDelivery =
            new DeliveryTimeFrameIndicator(nameof(ElectronicDelivery), "01");

        public static readonly DeliveryTimeFrameIndicator SameDayShipping = new DeliveryTimeFrameIndicator(nameof(SameDayShipping), "02");

        public static readonly DeliveryTimeFrameIndicator OverNightShipping =
            new DeliveryTimeFrameIndicator(nameof(OverNightShipping), "03");

        public static readonly DeliveryTimeFrameIndicator TwoDayOrMoreShipping =
            new DeliveryTimeFrameIndicator(nameof(TwoDayOrMoreShipping), "04");


        public DeliveryTimeFrameIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}