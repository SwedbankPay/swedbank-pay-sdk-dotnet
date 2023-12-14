namespace SwedbankPay.Sdk;

public record OrderItem(string Reference, string Name, OrderItemType Type, string Class, decimal Quantity,
    string QuantityUnit, Amount UnitPrice, int VatPercent, Amount Amount, Amount VatAmount)
{
    public Uri? Id { get; }
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

    internal OrderItem(OrderItemDto orderItemDto) : this(orderItemDto.Reference, orderItemDto.Name, orderItemDto.Type, orderItemDto.Class, orderItemDto.Quantity,
        orderItemDto.QuantityUnit, orderItemDto.UnitPrice, orderItemDto.VatPercent, orderItemDto.Amount, orderItemDto.VatAmount)
    {
        Id = !string.IsNullOrWhiteSpace(orderItemDto.Id) ? new Uri(orderItemDto.Id!, UriKind.RelativeOrAbsolute) : null;
        ItemUrl = orderItemDto.ItemUrl;
        ImageUrl = orderItemDto.ImageUrl;
        Description = orderItemDto.Description;
        DiscountDescription = orderItemDto.DiscountDescription;
        DiscountPrice = orderItemDto.DiscountPrice;
    }
}