namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates the merchandise delivery timeframe.
/// </summary>
public sealed class DeliveryTimeFrameIndicator : TypeSafeEnum<DeliveryTimeFrameIndicator>
{
    /// <summary>
    /// Delivery is electronic, no phyiscal shippment.
    /// </summary>
    public static readonly DeliveryTimeFrameIndicator ElectronicDelivery =
        new DeliveryTimeFrameIndicator(nameof(ElectronicDelivery), "01");

    /// <summary>
    /// Product is shipped same day as order is placed.
    /// </summary>
    public static readonly DeliveryTimeFrameIndicator SameDayShipping = new DeliveryTimeFrameIndicator(nameof(SameDayShipping), "02");

    /// <summary>
    /// Delivery is done over night.
    /// </summary>
    public static readonly DeliveryTimeFrameIndicator OverNightShipping =
        new DeliveryTimeFrameIndicator(nameof(OverNightShipping), "03");

    /// <summary>
    /// Shippment is expected to take two days or more.
    /// </summary>
    public static readonly DeliveryTimeFrameIndicator TwoDayOrMoreShipping =
        new DeliveryTimeFrameIndicator(nameof(TwoDayOrMoreShipping), "04");


    /// <summary>
    /// Instantiates a <see cref="DeliveryTimeFrameIndicator"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable name.</param>
    /// <param name="value">API value of the indicator.</param>
    public DeliveryTimeFrameIndicator(string name, string value)
        : base(name, value)
    {
    }
}