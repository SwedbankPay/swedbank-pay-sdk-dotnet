namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates when the shipping address used for this transaction was first used with the merchant.
    /// </summary>
    public sealed class ShippingAddressUsageIndicator : TypeSafeEnum<ShippingAddressUsageIndicator, string>
    {
        public static ShippingAddressUsageIndicator ThisTransaction { get; } = new ShippingAddressUsageIndicator(nameof(ThisTransaction), "01");
        public static ShippingAddressUsageIndicator LessThanThirtyDays { get; } = new ShippingAddressUsageIndicator(nameof(LessThanThirtyDays), "02");
        public static ShippingAddressUsageIndicator ThirtyToSixtyDays { get; } = new ShippingAddressUsageIndicator(nameof(ThirtyToSixtyDays), "03");
        public static ShippingAddressUsageIndicator MoreThanSixtyDays { get; } = new ShippingAddressUsageIndicator(nameof(MoreThanSixtyDays), "04");

        public ShippingAddressUsageIndicator(string name, string value) : base(name, value)
        {
        }
    }
}