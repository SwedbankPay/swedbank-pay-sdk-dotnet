namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class OrderItemDto
    {
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
        public int UnitPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int VatPercent { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }

        internal OrderItem Map()
        {
            var item = new OrderItem(Reference,
                                       Name,
                                       Type,
                                       Class,
                                       Quantity,
                                       QuantityUnit,
                                       UnitPrice,
                                       VatPercent,
                                       Amount,
                                       VatAmount)
            {
                ItemUrl = ItemUrl,
                ImageUrl = ImageUrl,
                Description = Description,
                DiscountDescription = DiscountDescription,
                DiscountPrice = DiscountPrice
            };

            return item;
        }
    }
}