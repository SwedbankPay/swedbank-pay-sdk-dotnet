using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class OrderItemsDto
    {
        public string Id { get; set; }
        public List<OrderItemDto> OrderItemList { get; set; } = new List<OrderItemDto>();

        internal OrderItems Map()
        {
            var list = new List<IOrderItem>();
            foreach (var item in OrderItemList)
            {
                list.Add(item.Map());
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            var orderItems = new OrderItems(uri)
            {
                OrderItemList = list
            };
            return orderItems;
        }
    }
}