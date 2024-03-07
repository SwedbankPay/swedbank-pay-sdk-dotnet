namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;

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