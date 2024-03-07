namespace SwedbankPay.Sdk.PaymentOrder.OrderItems;

public interface IOrderItem
{
    public string Reference { get; }
    public string Name { get; }
    public OrderItemType Type { get; }
    public string Class { get; }
    public decimal Quantity { get; }
    public string QuantityUnit { get; }
    public Amount UnitPrice { get; }
    public int VatPercent { get; }
    public Amount Amount { get; }
    public Amount VatAmount { get; }
    public string? ItemUrl { get; }
    public string? ImageUrl { get; }
    public string? Description { get; }
    public string? DiscountDescription { get; }
    public Amount? DiscountPrice { get; }
}