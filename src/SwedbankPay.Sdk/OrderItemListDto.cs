namespace SwedbankPay.Sdk;

public class OrderItemListItemDto //TODO ta bort?? Oanvänd?
{

    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Class { get; set; }
    public string? ItemUrl { get; set; }
    public string? ImageUrl { get; set; }
    public double Quantity { get; set; }
    public string? QuantityUnit { get; set; }
    public int UnitPrice { get; set; }
    public int DiscountPrice { get; set; }
    public int VatPercent { get; set; }
    public int Amount { get; set; }
    public int VatAmount { get; set; }
    public object[]? RestrictedToInstruments { get; set; }
}

