namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates shipping method chosen for the transaction.
/// </summary>
public sealed class ShipIndicator : TypeSafeEnum<ShipIndicator>
{
    /// <summary>
    /// Ship to card holders billing address.
    /// </summary>
    public static readonly ShipIndicator ShipToCardholdersBillingAddress =
        new ShipIndicator(nameof(ShipToCardholdersBillingAddress), "01");

    /// <summary>
    /// Ship to address verified at merchant.
    /// </summary>
    public static readonly ShipIndicator ShipToAnotherVerifiedAddressOnFileWithMerchant =
        new ShipIndicator(nameof(ShipToAnotherVerifiedAddressOnFileWithMerchant), "02");

    /// <summary>
    /// Ship to address different from the card holders billing address.
    /// </summary>
    public static readonly ShipIndicator ShipToAddressDifferentThanCardholdersBillingAddress =
        new ShipIndicator(nameof(ShipToAddressDifferentThanCardholdersBillingAddress), "03");

    /// <summary>
    ///     Ship to Store / Pick-up at local store.Store address shall be populated in shipping address fields
    /// </summary>
    public static readonly ShipIndicator ShipToStorePickupAtLocalStore = new ShipIndicator(nameof(ShipToStorePickupAtLocalStore), "04");

    /// <summary>
    ///     Digital goods, includes online services, electronic giftcards and redemption codes
    /// </summary>
    public static readonly ShipIndicator DigitalGoods = new ShipIndicator(nameof(DigitalGoods), "05");

    /// <summary>
    ///     Travel and Event tickets, not shipped
    /// </summary>
    public static readonly ShipIndicator TravelAndEventTicketsNotShipped =
        new ShipIndicator(nameof(TravelAndEventTicketsNotShipped), "06");

    /// <summary>
    ///     Other, e.g.gaming, digital service
    /// </summary>
    public static readonly ShipIndicator Other = new ShipIndicator(nameof(Other), "07");

    /// <summary>
    /// Instantiates a <see cref="ShipIndicator"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable name of the indicator.</param>
    /// <param name="value">API value of the indicator.</param>
    public ShipIndicator(string name, string value)
        : base(name, value)
    {
    }
}