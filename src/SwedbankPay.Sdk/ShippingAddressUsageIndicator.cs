namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Indicates when the shipping address used for this transaction was first used with the merchant.
    /// </summary>
    public sealed class ShippingAddressUsageIndicator : TypeSafeEnum<ShippingAddressUsageIndicator>
    {
        public static readonly ShippingAddressUsageIndicator ThisTransaction =
            new ShippingAddressUsageIndicator(nameof(ThisTransaction), "01");

        public static readonly ShippingAddressUsageIndicator LessThanThirtyDays =
            new ShippingAddressUsageIndicator(nameof(LessThanThirtyDays), "02");

        public static readonly ShippingAddressUsageIndicator ThirtyToSixtyDays =
            new ShippingAddressUsageIndicator(nameof(ThirtyToSixtyDays), "03");

        public static readonly ShippingAddressUsageIndicator MoreThanSixtyDays =
            new ShippingAddressUsageIndicator(nameof(MoreThanSixtyDays), "04");


        public ShippingAddressUsageIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}