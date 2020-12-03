using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API resource to access order items on a payment order.
    /// </summary>
    public class OrderItems : Identifiable
    {
        /// <summary>
        /// Instantiates a <see cref="OrderItems"/> with the provided parameters.
        /// </summary>
        /// <param name="id">Unique ID for this resource.</param>
        /// <param name="orderItemList">Enumerable list of <seealso cref="OrderItem"/>s.</param>
        public OrderItems(Uri id, IEnumerable<OrderItem> orderItemList)
        {
            Id = id;
            OrderItemList = orderItemList;
        }
        /// <summary>
        ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
        ///     to print on invoices if
        ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
        ///     creation as well as on Capture.
        /// </summary>
        public IEnumerable<OrderItem> OrderItemList { get; set; }
    }
}