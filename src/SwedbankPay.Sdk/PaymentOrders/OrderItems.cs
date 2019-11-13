namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Collections.Generic;

    public class OrderItems : IdLink
    {
        /// <summary>
        /// The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used to print on invoices if
        /// the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order creation as well as on Capture.
        /// </summary>
        public List<OrderItem> OrderItemList { get; set; }
    }
}