namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
/// </summary>
public sealed class PreOrderPurchaseIndicator : TypeSafeEnum<PreOrderPurchaseIndicator>
{
    /// <summary>
    /// Merchandise is available.
    /// </summary>
    public static readonly PreOrderPurchaseIndicator MerchandiseAvailable =
        new PreOrderPurchaseIndicator(nameof(MerchandiseAvailable), "01");

    /// <summary>
    /// Merchandise is available at a later date.
    /// </summary>
    public static readonly PreOrderPurchaseIndicator FutureAvailability =
        new PreOrderPurchaseIndicator(nameof(FutureAvailability), "02");

    /// <summary>
    /// Instantiates a <see cref="PreOrderPurchaseIndicator"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable name of the indicator.</param>
    /// <param name="value">API value of the indicator.</param>
    public PreOrderPurchaseIndicator(string name, string value)
        : base(name, value)
    {
    }
}