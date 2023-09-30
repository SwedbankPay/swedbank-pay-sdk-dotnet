namespace SwedbankPay.Sdk;

public record OrderItem(string Reference, string Name, OrderItemType Type, string Class, int Quantity,
    string QuantityUnit, Amount UnitPrice, int VatPercent, Amount Amount, Amount VatAmount)
{
    public string? ItemUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? DiscountDescription { get; set; }
    public int? DiscountPrice { get; set; }
}