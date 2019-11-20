namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates shipping method chosen for the transaction.
    /// </summary>
    public sealed class ShipIndicator : TypeSafeEnum<ShipIndicator, string>
    {
        public static readonly ShipIndicator ShipToCardholdersBillingAddress = new ShipIndicator(nameof(ShipToCardholdersBillingAddress), "01");
        public static readonly ShipIndicator ShipToAnotherVerifiedAddressOnFileWithMerchant = new ShipIndicator(nameof(ShipToAnotherVerifiedAddressOnFileWithMerchant), "02");
        public static readonly ShipIndicator ShipToAddressDifferentThanCardholdersBillingAddress = new ShipIndicator(nameof(ShipToAddressDifferentThanCardholdersBillingAddress), "03");

        /// <summary>
        /// Ship to Store / Pick-up at local store.Store address shall be populated in shipping address fields
        /// </summary>
        public static readonly ShipIndicator ShipToStorePickupAtLocalStore = new ShipIndicator(nameof(ShipToStorePickupAtLocalStore), "04");

        /// <summary>
        /// Digital goods, includes online services, electronic giftcards and redemption codes
        /// </summary>
        public static readonly ShipIndicator DigitalGoods = new ShipIndicator(nameof(DigitalGoods), "05");

        /// <summary>
        /// Travel and Event tickets, not shipped
        /// </summary>
        public static readonly ShipIndicator TravelAndEventTicketsNotShipped = new ShipIndicator(nameof(TravelAndEventTicketsNotShipped), "06");

        /// <summary>
        /// Other, e.g.gaming, digital service
        /// </summary>
        public static readonly ShipIndicator Other = new ShipIndicator(nameof(Other), "07");

        public ShipIndicator(string name, string value) : base(name, value)
        {
        }
    }
}