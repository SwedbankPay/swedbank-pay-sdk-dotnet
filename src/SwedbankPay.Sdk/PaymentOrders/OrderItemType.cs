namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     PRODUCT, SERVICE, SHIPPING_FEE, PAYMENT_FEE, DISCOUNT, VALUE_CODE or OTHER. The type of the order item.
    /// </summary>
    public sealed class OrderItemType : TypeSafeEnum<OrderItemType>
    {
        /// <summary>
        /// The order item type is a product.
        /// </summary>
        public static readonly OrderItemType Product = new OrderItemType(nameof(Product), "PRODUCT");

        /// <summary>
        /// The order item type is a service.
        /// </summary>
        public static readonly OrderItemType Service = new OrderItemType(nameof(Service), "SERVICE");

        /// <summary>
        /// The order item type is a shipping fee.
        /// </summary>
        public static readonly OrderItemType ShippingFee = new OrderItemType(nameof(ShippingFee), "SHIPPING_FEE");

        /// <summary>
        /// The order item type is a payment fee.
        /// </summary>
        public static readonly OrderItemType PaymentFee = new OrderItemType(nameof(PaymentFee), "PAYMENT_FEE");

        /// <summary>
        /// The order item type is a discount.
        /// </summary>
        public static readonly OrderItemType Discount = new OrderItemType(nameof(Discount), "DISCOUNT");

        /// <summary>
        /// The order item type is a value code.
        /// </summary>
        public static readonly OrderItemType ValueCode = new OrderItemType(nameof(ValueCode), "VALUE_CODE");

        /// <summary>
        /// The order item type is other.
        /// </summary>
        public static readonly OrderItemType Other = new OrderItemType(nameof(Other), "OTHER");

        /// <summary>
        /// Instantaites a <see cref="OrderItemType"/> with the provided parameters.
        /// </summary>
        /// <param name="name">The human readable name of the type.</param>
        /// <param name="value">The API value of the type.</param>
        public OrderItemType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="OrderItemType"/>.
        /// </summary>
        /// <param name="type">The API value to convert.</param>
        public static implicit operator OrderItemType(string type)
        {
            return type switch
            {
                "PRODUCT" => Product,
                "SERVICE" => Service,
                "SHIPPING_FEE" => ShippingFee,
                "PAYMENT_FEE" => PaymentFee,
                "DISCOUNT" => Discount,
                "VALUE_CODE" => ValueCode,
                "OTHER" => Other,
                _ => new OrderItemType(type, type),
            };
        }
    }
}