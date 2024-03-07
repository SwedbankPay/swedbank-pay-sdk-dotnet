namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates when the shipping address used for this transaction was first used with the merchant.
/// </summary>
public sealed class ShippingAddressUsageIndicator : TypeSafeEnum<ShippingAddressUsageIndicator>
{
    /// <summary>
    /// Shipping address was first used for this transaction.
    /// </summary>
    public static readonly ShippingAddressUsageIndicator ThisTransaction =
        new ShippingAddressUsageIndicator(nameof(ThisTransaction), "01");

    /// <summary>
    /// Shipping address was last used less than thirty days ago.
    /// </summary>
    public static readonly ShippingAddressUsageIndicator LessThanThirtyDays =
        new ShippingAddressUsageIndicator(nameof(LessThanThirtyDays), "02");

    /// <summary>
    /// Shipping addres was used between thirty to sixy days ago.
    /// </summary>
    public static readonly ShippingAddressUsageIndicator ThirtyToSixtyDays =
        new ShippingAddressUsageIndicator(nameof(ThirtyToSixtyDays), "03");

    /// <summary>
    /// Shipping address was used more than sixty days ago.
    /// </summary>
    public static readonly ShippingAddressUsageIndicator MoreThanSixtyDays =
        new ShippingAddressUsageIndicator(nameof(MoreThanSixtyDays), "04");

    /// <summary>
    /// Instantiates a <see cref="ShippingAddressUsageIndicator"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable name of the indicator.</param>
    /// <param name="value">API value of the indicator.</param>
    public ShippingAddressUsageIndicator(string name, string value)
        : base(name, value)
    {
    }
}