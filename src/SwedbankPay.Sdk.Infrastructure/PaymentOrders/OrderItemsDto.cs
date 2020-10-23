using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class OrderItemsDto
    {
        public string Id { get; set; }
        public List<OrderItemListDto> OrderItemList { get; set; }

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
                                       item.VatPercent,
                                       item.ItemUrl,
                                       item.ImageUrl,
                                       item.Description,
                                       item.DiscountDescription,
                                       item.DiscountPrice));
            }
            new OrderItems(list);
            throw new NotImplementedException();
        }
    }
}