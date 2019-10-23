namespace SwedbankPay.Sdk.Models.Common
{
    using System.Collections.Generic;

    public class OrderItems : IdLink
    {
        public List<OrderItem> OrderItemList { get; set; }
    }
}