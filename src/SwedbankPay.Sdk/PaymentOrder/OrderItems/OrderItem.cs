namespace SwedbankPay.Sdk.PaymentOrder.OrderItems;

public record OrderItem(string Reference, string Name, OrderItemType Type, string Class, decimal Quantity,
    string QuantityUnit, Amount UnitPrice, int VatPercent, Amount Amount, Amount VatAmount)
{
    public string Reference { get; } = Reference;
    public string Name { get; } = Name;
    public OrderItemType Type { get; } = Type;
    public string Class { get; } = Class;
    public decimal Quantity { get; } = Quantity;
    public string QuantityUnit { get; } = QuantityUnit;
    public Amount UnitPrice { get; } = UnitPrice;
    public int VatPercent { get; } = VatPercent;
    public Amount Amount { get; } = Amount;
    public Amount VatAmount { get; } = VatAmount;
    public string? ItemUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? DiscountDescription { get; set; }
    public Amount? DiscountPrice { get; set; }
}