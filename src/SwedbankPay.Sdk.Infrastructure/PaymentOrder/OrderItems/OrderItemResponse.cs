using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;

internal record OrderItemResponse : IOrderItem
{
    public OrderItemResponse(OrderItemResponseDto orderItemResponseDto)
    {
        Reference = orderItemResponseDto.Reference;
        Name = orderItemResponseDto.Name;
        Type = orderItemResponseDto.Type;
        Class = orderItemResponseDto.Class;
        Quantity = orderItemResponseDto.Quantity;
        QuantityUnit = orderItemResponseDto.QuantityUnit;
        UnitPrice = orderItemResponseDto.UnitPrice;
        VatPercent = orderItemResponseDto.VatPercent;
        Amount = orderItemResponseDto.Amount;
        VatAmount = orderItemResponseDto.VatAmount;
        ItemUrl = orderItemResponseDto.ItemUrl;
        ImageUrl = orderItemResponseDto.ImageUrl;
        Description = orderItemResponseDto.Description;
        DiscountDescription = orderItemResponseDto.DiscountDescription;
        DiscountPrice = orderItemResponseDto.DiscountPrice;
    }

    public string? Reference { get; }
    public string? Name { get; }
    public OrderItemType? Type { get; }
    public string? Class { get; }
    public decimal? Quantity { get; }
    public string? QuantityUnit { get; }
    public Amount? UnitPrice { get; }
    public int VatPercent { get; }
    public Amount? Amount { get; }
    public Amount? VatAmount { get; }
    public string? ItemUrl { get; }
    public string? ImageUrl { get; }
    public string? Description { get; }
    public string? DiscountDescription { get; }
    public Amount? DiscountPrice { get; }
}