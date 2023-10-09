using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk;

internal record OrderItemDto
{
    [JsonConstructor]
    public OrderItemDto() { }
    
    internal OrderItemDto(OrderItem orderItem)
    {
        Reference = orderItem.Reference;
        Name = orderItem.Name;
        Type = orderItem.Type.Value;
        Class = orderItem.Class;
        ItemUrl = orderItem.ItemUrl;
        ImageUrl = orderItem.ImageUrl;
        Description = orderItem.Description;
        DiscountDescription = orderItem.DiscountDescription;
        Quantity = orderItem.Quantity;
        QuantityUnit = orderItem.QuantityUnit;
        UnitPrice = orderItem.UnitPrice.InLowestMonetaryUnit;
        DiscountPrice = orderItem.DiscountPrice;
        VatPercent = orderItem.VatPercent;
        Amount = orderItem.Amount.InLowestMonetaryUnit;
        VatAmount = orderItem.VatAmount.InLowestMonetaryUnit;
    }
    public string? Id { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Class { get; set; }
    public string? ItemUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? DiscountDescription { get; set; }
    public decimal Quantity { get; set; }
    public string? QuantityUnit { get; set; }
    public long UnitPrice { get; set; }
    public int? DiscountPrice { get; set; }
    public int VatPercent { get; set; }
    public long Amount { get; set; }
    public long VatAmount { get; set; }

    internal OrderItem Map()
    {
        return new OrderItem(this);
    }
}