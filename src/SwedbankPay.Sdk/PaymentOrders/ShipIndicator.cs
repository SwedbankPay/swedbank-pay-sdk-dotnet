namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates shipping method chosen for the transaction.
    /// </summary>
    public sealed class ShipIndicator : TypeSafeEnum<ShipIndicator, string>
    {
        public static ShipIndicator ShipToCardholdersBillingAddress { get; } = new ShipIndicator(nameof(ShipToCardholdersBillingAddress), "01");
        public static ShipIndicator ShipToAnotherVerifiedAddressOnFileWithMerchant { get; } = new ShipIndicator(nameof(ShipToAnotherVerifiedAddressOnFileWithMerchant), "02");
        public static ShipIndicator ShipToAddressDifferentThanCardholdersBillingAddress { get; } = new ShipIndicator(nameof(ShipToAddressDifferentThanCardholdersBillingAddress), "03");
        /// <summary>
        /// Ship to Store / Pick-up at local store.Store address shall be populated in shipping address fields
        /// </summary>
        public static ShipIndicator ShipToStorePickupAtLocalStore { get; } = new ShipIndicator(nameof(ShipToStorePickupAtLocalStore), "04");
        /// <summary>
        /// Digital goods, includes online services, electronic giftcards and redemption codes
        /// </summary>
        public static ShipIndicator DigitalGoods { get; } = new ShipIndicator(nameof(DigitalGoods), "05");
        /// <summary>
        /// Travel and Event tickets, not shipped
        /// </summary>
        public static ShipIndicator TravelAndEventTicketsNotShipped { get; } = new ShipIndicator(nameof(TravelAndEventTicketsNotShipped), "06");
        /// <summary>
        /// Other, e.g.gaming, digital service
        /// </summary>
        public static ShipIndicator Other { get; } = new ShipIndicator(nameof(Other), "06");
        public ShipIndicator(string name, string value) : base(name, value)
        {
        }
    }
}