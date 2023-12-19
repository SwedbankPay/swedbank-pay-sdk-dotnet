using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;

internal record OrderItemsResponse : Identifiable, IOrderItemsResponse
{
    /// <summary>
    ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
    ///     to print on invoices if
    ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
    ///     creation as well as on Capture.
    /// </summary>
    public IEnumerable<IOrderItem>? OrderItemList { get; }

    internal OrderItemsResponse(OrderItemsResponseDto dto) : base(dto.Id)
    {
        OrderItemList = dto.OrderItemList?.Select(item => item.Map()).ToList();
    }
}