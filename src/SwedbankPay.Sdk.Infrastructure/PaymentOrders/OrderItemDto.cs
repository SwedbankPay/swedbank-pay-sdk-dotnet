using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.PaymentOrders
{
	internal class OrderItemDto
    {
        public OrderItemDto() { }

        public OrderItemDto(IOrderItem item)
        {
            if (item == null)
            {
                return;
            }

            Amount = item.Amount.InLowestMonetaryUnit;
            Class = item.Class;
            Description = item.Description;
            DiscountDescription = item.DiscountDescription;
            DiscountPrice = item.DiscountPrice?.InLowestMonetaryUnit;
            ImageUrl = item.ImageUrl;
            ItemUrl = item.ItemUrl;
            Name = item.Name;
            Quantity = item.Quantity;
            QuantityUnit = item.QuantityUnit;
            Reference = item.Reference;
            Type = item.Type.Value;
            UnitPrice = item.UnitPrice.InLowestMonetaryUnit;
            VatAmount = item.VatAmount.InLowestMonetaryUnit;
            VatPercent = item.VatPercent;
            RestrictedToInstruments = item.RestrictedToInstruments?.Select(item => item.Value).ToList();
        }

        public string Reference { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public string ItemUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string DiscountDescription { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public long UnitPrice { get; set; }
        public long? DiscountPrice { get; set; }
        public int VatPercent { get; set; }
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public List<string> RestrictedToInstruments { get; set; }

        internal IOrderItem Map()
        {
            return new OrderItem(this);
        }
    }
}