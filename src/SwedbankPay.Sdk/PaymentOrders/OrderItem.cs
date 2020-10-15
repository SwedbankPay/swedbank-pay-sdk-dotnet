using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class OrderItem
    {
        public OrderItem(string reference,
                         string name,
                         OrderItemType type,
                         string @class,
                         decimal quantity,
                         string quantityUnit,
                         Amount unitPrice,
                         int vatPercent,
                         Amount amount,
                         Amount vatAmount,
                         string itemUrl = null,
                         string imageUrl = null,
                         string description = null,
                         string discountDescription = null,
                         Amount discountPrice = null)
        {
            if (string.IsNullOrEmpty(reference)) throw new ArgumentException($"Required input {reference} was empty.", reference);
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"Required input {name} was empty.", name);
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), $"Required input {quantity} must be equal or greater than 1.");
            if (string.IsNullOrEmpty(quantityUnit)) throw new ArgumentException($"Required input {quantityUnit} was empty.", quantityUnit);

            Reference = reference;
            Name = name;
            Type = type;
            Class = @class;
            ItemUrl = itemUrl;
            ImageUrl = imageUrl;
            Description = description;
            DiscountDescription = discountDescription;
            DiscountPrice = discountPrice;
            Quantity = quantity;
            QuantityUnit = quantityUnit;
            UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
            VatPercent = vatPercent;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            VatAmount = vatAmount ?? throw new ArgumentNullException(nameof(amount));
        }


        /// <summary>
        ///     The total amount including VAT to be paid for the specified quantity of this order item, in the lowest monetary
        ///     unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        ///     The classification of the order item. Can be used for assigning the order item to a specific product category, for
        ///     instance. PayEx has no use for this value itself, but it's useful for some payment instruments and integrations.
        /// </summary>
        public string Class { get; }

        /// <summary>
        ///     The human readable description of the order item.
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     The human readable description of the possible discount.
        /// </summary>
        public string DiscountDescription { get; }

        /// <summary>
        ///     If the order item is purchased at a discounted price, this property should contain that price.
        /// </summary>
        public Amount DiscountPrice { get; }

        /// <summary>
        ///     The URL to an image of the order item.
        /// </summary>
        public string ImageUrl { get; }

        /// <summary>
        ///     The URL to a page that can display the purchased item, such as a product page
        /// </summary>
        public string ItemUrl { get; }

        /// <summary>
        ///     The name of the order item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The quantity of order items being purchased.
        /// </summary>
        public decimal Quantity { get; }

        /// <summary>
        ///     The unit of the quantity, such as pcs, grams, or similar.
        /// </summary>
        public string QuantityUnit { get; }

        /// <summary>
        ///     A reference that identifies the order item.
        /// </summary>
        public string Reference { get; }

        /// <summary>
        ///     PRODUCT, SERVICE, SHIPPING_FEE, DISCOUNT, VALUE_CODE or OTHER. The type of the order item.
        /// </summary>
        public OrderItemType Type { get; }

        /// <summary>
        ///     The price per unit of order item.
        /// </summary>
        public Amount UnitPrice { get; }

        /// <summary>
        ///     The total amount of VAT to be paid for the specified quantity of this order item, in the lowest monetary unit of
        ///     the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00 NOK.
        /// </summary>
        public Amount VatAmount { get; }

        /// <summary>
        ///     The percent value of the VAT multiplied by 100, so 25% becomes 2500.
        /// </summary>
        public int VatPercent { get; }
    }
}