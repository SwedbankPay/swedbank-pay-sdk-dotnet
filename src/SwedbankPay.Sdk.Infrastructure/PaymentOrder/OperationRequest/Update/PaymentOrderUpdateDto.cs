using SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.Update;

internal record PaymentOrderUpdateDto
{
    internal PaymentOrderUpdateDto(PaymentOrderUpdateRequestDetails paymentOrder)
    {
        Amount = paymentOrder.Amount.InLowestMonetaryUnit;
        Operation = paymentOrder.Operation.Value;
        VatAmount = paymentOrder.VatAmount.InLowestMonetaryUnit;
        foreach (var item in paymentOrder.OrderItems)
        {
            OrderItems.Add(new OrderItemRequestDto(item));
        }
    }

    public long Amount { get; }

    public string Operation { get; }

    public long? VatAmount { get; }

    public IList<OrderItemRequestDto> OrderItems { get; } = new List<OrderItemRequestDto>();
}