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
        public long Amount { get; set; }
        public long VatAmount { get; set; }

        internal IOrderItem Map()
        {
            return new OrderItem(this);
        }
    }
}