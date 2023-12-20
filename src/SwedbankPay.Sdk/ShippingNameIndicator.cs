namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.
/// </summary>
public sealed class ShippingNameIndicator : TypeSafeEnum<ShippingNameIndicator>
{
    /// <summary>
    /// Card holder name is identical to shipping name.
    /// </summary>
    public static readonly ShippingNameIndicator AccountNameIdenticalToShippingName =
        new ShippingNameIndicator("Account name identical to shipping name", "01");

    /// <summary>
    /// Card holder name is different form shipping name.
    /// </summary>
    public static readonly ShippingNameIndicator AccountNameDifferentFromShippingName =
        new ShippingNameIndicator("Account name different than shipping name", "02");

    /// <summary>
    /// Initializes a <see cref="ShippingNameIndicator"/> with the provided parameters.
    /// </summary>
    /// <param name="name">The human readable name of the indicator.</param>
    /// <param name="value">The API value of the indicator.</param>
    public ShippingNameIndicator(string name, string value)
        : base(name, value)
    {
    }
}