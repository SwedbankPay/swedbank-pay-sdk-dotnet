namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Collections.Generic;

    public class OrderItems : IdLink
    {
        public List<OrderItem> OrderItemList { get; set; }
    }
}