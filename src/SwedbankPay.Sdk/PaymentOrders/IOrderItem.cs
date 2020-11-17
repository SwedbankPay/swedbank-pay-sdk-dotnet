namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IOrderItem
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The classification of the order item.
        /// Can be used for assigning the order item to a specific product category,
        /// such as MobilePhone.
        /// Note that class cannot contain spaces and must follow the regex pattern [\w-]*.
        /// Swedbank Pay may use this field for statistics.
        /// </summary>
        string Class { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Human readable description of the possible discount.
        /// </summary>
        string DiscountDescription { get; }

        /// <summary>
        /// If the order item is purchased at a discounted price this field should contain that price, including VAT.
        /// </summary>
        Amount DiscountPrice { get; }

        /// <summary>
        /// The URL to an image of the order item.
        /// </summary>
        string ImageUrl { get; }

        /// <summary>
        /// The URL to a page that can display the purchased item, product or similar.
        /// </summary>
        string ItemUrl { get; }

        /// <summary>
        /// The name of the order item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The 4 decimal precision quantity of order items being purchased.
        /// </summary>
        decimal Quantity { get; }

        /// <summary>
        /// The unit of the quantity, such as pcs, grams, or similar.
        /// This is a free-text field and is used for your own book keeping.
        /// </summary>
        string QuantityUnit { get; }

        /// <summary>
        /// Your reference that identifies the order item.
        /// </summary>
        string Reference { get; }

        /// <summary>
        /// The type of the order item.
        /// <seealso cref="OrderItemType.PaymentFee"/> is the amount you are charged with when you are paying with invoice.
        /// The amount can be defined in the <see cref="Amount"/> field.
        /// </summary>
        OrderItemType Type { get; }

        /// <summary>
        /// The price per unit of order item, including VAT.
        /// </summary>
        Amount UnitPrice { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        Amount VatAmount { get; }

        /// <summary>
        /// The percent value of the VAT multiplied by 100, so 25% becomes 2500.
        /// </summary>
        int VatPercent { get; }
    }
}