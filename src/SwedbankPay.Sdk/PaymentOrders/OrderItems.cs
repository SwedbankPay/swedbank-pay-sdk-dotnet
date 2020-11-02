using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class OrderItems : IdLink
    {
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