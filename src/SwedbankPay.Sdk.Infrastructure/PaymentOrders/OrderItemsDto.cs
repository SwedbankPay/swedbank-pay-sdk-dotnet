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
            throw new NotImplementedException();
        }
    }
}