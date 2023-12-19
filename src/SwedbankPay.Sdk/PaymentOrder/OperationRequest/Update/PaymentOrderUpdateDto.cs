using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;

internal record PaymentOrderUpdateDto
{
    internal PaymentOrderUpdateDto(PaymentOrderUpdateRequestDetails paymentOrder)
    {
        Amount = paymentOrder.Amount.InLowestMonetaryUnit;
        Operation = paymentOrder.Operation.Value;
        VatAmount = paymentOrder.VatAmount.InLowestMonetaryUnit;
        foreach (var item in paymentOrder.OrderItems)
        {
            OrderItems.Add(new OrderItemDto(item));
        }
    }

    public long Amount { get; }

    public string Operation { get; }

    public long? VatAmount { get; }

    public IList<OrderItemDto> OrderItems { get; } = new List<OrderItemDto>();
}