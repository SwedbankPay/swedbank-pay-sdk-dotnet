namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     PRODUCT, SERVICE, SHIPPING_FEE, PAYMENT_FEE, DISCOUNT, VALUE_CODE or OTHER. The type of the order item.
    /// </summary>
    public sealed class OrderItemType : TypeSafeEnum<OrderItemType, string>
    {
        public static readonly OrderItemType Product = new OrderItemType(nameof(Product), "PRODUCT");
        public static readonly OrderItemType Service = new OrderItemType(nameof(Service), "SERVICE");
        public static readonly OrderItemType ShippingFee = new OrderItemType(nameof(ShippingFee), "SHIPPING_FEE");
        public static readonly OrderItemType PaymentFee = new OrderItemType(nameof(PaymentFee), "PAYMENT_FEE");
        public static readonly OrderItemType Discount = new OrderItemType(nameof(Discount), "DISCOUNT");
        public static readonly OrderItemType ValueCode = new OrderItemType(nameof(ValueCode), "VALUE_CODE");
        public static readonly OrderItemType Other = new OrderItemType(nameof(Other), "OTHER");


        public OrderItemType(string name, string value)
            : base(name, value)
        {
        }

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