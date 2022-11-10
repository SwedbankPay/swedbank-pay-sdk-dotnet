namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
/// </summary>
public sealed class ReOrderPurchaseIndicator : TypeSafeEnum<ReOrderPurchaseIndicator>
{
    /// <summary>
    /// Merchandise is available at release date.
    /// </summary>
    public static readonly ReOrderPurchaseIndicator MerchandiseAvailable =
        new ReOrderPurchaseIndicator(nameof(MerchandiseAvailable), "01");

    /// <summary>
    /// Merchandise is available at a later date.
    /// </summary>
    public static readonly ReOrderPurchaseIndicator FutureAvailability = new ReOrderPurchaseIndicator(nameof(FutureAvailability), "02");

    /// <summary>
    /// Instantiates a <see cref="ReOrderPurchaseIndicator"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable name of the indicator.</param>
    /// <param name="value">API value of the indicator.</param>
    public ReOrderPurchaseIndicator(string name, string value)
        : base(name, value)
    {
    }
}