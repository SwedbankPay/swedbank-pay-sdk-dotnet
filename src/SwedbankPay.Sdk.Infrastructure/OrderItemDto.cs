namespace SwedbankPay.Sdk
{
    internal class OrderItemDto
    {
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
        }

        public long Amount { get; }

        public string Class { get; }

        public string Description { get; }

        public string DiscountDescription { get; }

        public long? DiscountPrice { get; }

        public string ImageUrl { get; }

        public string ItemUrl { get; }

        public string Name { get; }

        public decimal Quantity { get; }

        public string QuantityUnit { get; }

        public string Reference { get; }

        public string Type { get; }

        public long UnitPrice { get; }

        public long VatAmount { get; }

        public int VatPercent { get; }
    }
}