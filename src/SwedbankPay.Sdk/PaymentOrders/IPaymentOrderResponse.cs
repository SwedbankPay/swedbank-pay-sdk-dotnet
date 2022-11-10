namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// API response giving access to the current payment
/// order and available operations.
/// </summary>
public interface IPaymentOrderResponse
{
    /// <summary>
    /// Currently available operations of this payment order.
    /// </summary>
    IPaymentOrderOperations Operations { get; }

    /// <summary>
    /// The current payment order.
    /// </summary>
    IPaymentOrder PaymentOrder { get; }
}