using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IOrderItem
    {
        Amount Amount { get; }
        string Class { get; }
        string Description { get; }
        string DiscountDescription { get; }
        Amount DiscountPrice { get; }
        string ImageUrl { get; }
        string ItemUrl { get; }
        string Name { get; }
        decimal Quantity { get; }
        string QuantityUnit { get; }
        string Reference { get; }
        OrderItemType Type { get; }
        Amount UnitPrice { get; }
        Amount VatAmount { get; }
        int VatPercent { get; }
    }
}