namespace SwedbankPay.Sdk;

public record OrderItem(string Reference, string Name, OrderItemType Type, string Class, decimal Quantity,
    string QuantityUnit, Amount UnitPrice, int VatPercent, Amount Amount, Amount VatAmount)
{
    public string? ItemUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? DiscountDescription { get; set; }
    public int? DiscountPrice { get; set; }

    internal OrderItem(OrderItemDto orderItemDto) : this(orderItemDto.Reference, orderItemDto.Name, orderItemDto.Type, orderItemDto.Class, orderItemDto.Quantity,
        orderItemDto.QuantityUnit, orderItemDto.UnitPrice, orderItemDto.VatPercent, orderItemDto.Amount, orderItemDto.VatAmount)
    {
        ItemUrl = orderItemDto.ItemUrl;
        ImageUrl = orderItemDto.ImageUrl;
        Description = orderItemDto.Description;
        DiscountDescription = orderItemDto.DiscountDescription;
        DiscountPrice = orderItemDto.DiscountPrice;
    }
}