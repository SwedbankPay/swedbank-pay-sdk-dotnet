namespace SwedbankPay.Sdk.PaymentOrder.OrderItems;

public interface IOrderItemsResponse
{
    Uri Id { get; }
    IEnumerable<IOrderItem>? OrderItemList { get; }
}