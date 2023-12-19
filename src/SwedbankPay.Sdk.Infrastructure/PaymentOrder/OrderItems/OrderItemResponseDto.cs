namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;

internal record OrderItemResponseDto
{
    public string Reference { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Type { get; init; } = null!;
    public string Class { get; init; } = null!;
    public decimal Quantity { get; init; }
    public string QuantityUnit { get; init; } = null!;
    public long UnitPrice { get; init; }
    public int VatPercent { get; init; }
    public long Amount { get; init; }
    public long VatAmount { get; init; }
    public string? ItemUrl { get; init; }
    public string? ImageUrl { get; init; }
    public string? Description { get; init; }
    public string? DiscountDescription { get; init; }
    public long? DiscountPrice { get; init; }

    public OrderItemResponse Map()
    {
        return new OrderItemResponse(this);
    }
}