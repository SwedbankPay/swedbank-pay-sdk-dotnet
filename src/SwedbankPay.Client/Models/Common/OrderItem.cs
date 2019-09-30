namespace SwedbankPay.Client.Models.Common
{
    public class OrderItem
    {
        /// <summary>
        /// A reference that identifies the order item.
        /// </summary>
        public string Reference { get; set; }


        /// <summary>
        /// The name of the order item.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// PRODUCT, SERVICE, SHIPPING_FEE, DISCOUNT, VALUE_CODE or OTHER. The type of the order item.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The classification of the order item. Can be used for assigning the order item to a specific product category, for instance. PayEx has no use for this value itself, but it's useful for some payment instruments and integrations.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// The URL to a page that contains a human readable description of the order item, or similar.
        /// </summary>
        public string ItemUrl { get; set; }

        public string ImageUrl { get; set; }

        /// <summary>
        /// The human readable description of the order item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The human readable description of the possible discount.
        /// </summary>
        public string DiscountDescription { get; set; }

        /// <summary>
        /// The quantity of order items being purchased.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// The unit of the quantity, such as pcs, grams, or similar.
        /// </summary>
        public string QuantityUnit { get; set; }

        /// <summary>
        /// The price per unit of order item.
        /// </summary>
        public long? UnitPrice { get; set; }

        /// <summary>
        /// If the order item is purchased at a discounted price, this property should contain that price.
        /// </summary>
        public long? DiscountPrice { get; set; }

        /// <summary>
        /// The percent value of the VAT multiplied by 100, so 25% becomes 2500.
        /// </summary>
        public int? VatPercent { get; set; }

        /// <summary>
        /// The total amount including VAT to be paid for the specified quantity of this order item, in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// The total amount of VAT to be paid for the specified quantity of this order item, in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public int? VatAmount { get; set; }
    }
}
