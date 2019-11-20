namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.
    /// </summary>
    public sealed class ShippingNameIndicator : TypeSafeEnum<ShippingNameIndicator, string>
    {
        public static readonly ShippingNameIndicator AccountNameIdenticalToShippingName = new ShippingNameIndicator("Account name identical to shipping name", "01");
        public static readonly ShippingNameIndicator AccountNameDifferentFromShippingName = new ShippingNameIndicator("Account name different than shipping name", "02");

        public ShippingNameIndicator(string name, string value) : base(name, value)
        {
        }
    }
}