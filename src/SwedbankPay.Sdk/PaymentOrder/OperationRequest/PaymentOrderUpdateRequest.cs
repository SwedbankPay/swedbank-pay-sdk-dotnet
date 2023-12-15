using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

/// <summary>
/// API request details for updating a payment order.
/// </summary>
public record PaymentOrderUpdateRequest
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderUpdateRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount to update to.</param>
    /// <param name="vatAmount">The VAT amount to update to.</param>
    public PaymentOrderUpdateRequest(Amount amount, Amount vatAmount)
    {
        PaymentOrder = new PaymentOrderUpdateRequestDetails(amount, vatAmount);
    }

    /// <summary>
    /// Details about the amount being updated.
    /// </summary>
    public PaymentOrderUpdateRequestDetails PaymentOrder { get; }
}

internal record PaymentOrderUpdateRequestDto
{
    public PaymentOrderUpdateRequestDto(PaymentOrderUpdateRequest payload)
    {
        PaymentOrder = new PaymentOrderUpdateDto(payload.PaymentOrder);
    }

    public PaymentOrderUpdateDto PaymentOrder { get; }
}

internal record PaymentOrderUpdateDto
{
    public PaymentOrderUpdateDto(PaymentOrderUpdateRequestDetails paymentOrder)
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