namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;

internal record OrderItemResponseDto
{
    public string Reference { get; init; }
    public string Name { get; init;}
    public string Type { get; init;}
    public string Class { get; init;}
    public decimal Quantity { get; init;}
    public string QuantityUnit { get; init;}
    public long UnitPrice { get; init;}
    public int VatPercent { get; init;}
    public long Amount { get; init;}
    public long VatAmount { get; init;}
    public string? ItemUrl { get; init;}
    public string? ImageUrl { get; init;}
    public string? Description { get; init;}
    public string? DiscountDescription { get; init;}
    public long? DiscountPrice { get; init;}

    public OrderItemResponse Map()
    {
        return new OrderItemResponse(this);
    }
}