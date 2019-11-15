namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.
    /// </summary>
    public sealed class ShippingNameIndicator : TypeSafeEnum<ShippingNameIndicator, string>
    {
        public static ShippingNameIndicator AccountNameIdenticalToShippingName { get; } = new ShippingNameIndicator("Account name identical to shipping name", "01");
        public static ShippingNameIndicator AccountNameDifferentFromShippingName { get; } = new ShippingNameIndicator("Account name different than shipping name", "02");
        public ShippingNameIndicator(string name, string value) : base(name, value)
        {
        }
    }
}