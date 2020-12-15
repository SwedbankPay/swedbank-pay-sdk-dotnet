using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class OrderItemsDto
    {
        public string Id { get; set; }
        public List<OrderItemListDto> OrderItemList { get; set; } = new List<OrderItemListDto>();

        internal OrderItems Map()
        {
            var list = new List<OrderItem>();
            foreach (var item in OrderItemList)
            {
                list.Add(new OrderItem(item.Reference,
                                       item.Name,
                                       item.Type,
                                       item.Class,
                                       item.Quantity,
                                       item.QuantityUnit,
                                       item.UnitPrice,
                                       item.VatPercent,
                                       item.Amount,
                                       item.VatAmount)
                {
                    ItemUrl = item.ItemUrl,
                    ImageUrl = item.ImageUrl,
                    Description = item.Description,
                    DiscountDescription = item.DiscountDescription,
                    DiscountPrice = item.DiscountPrice
                });
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