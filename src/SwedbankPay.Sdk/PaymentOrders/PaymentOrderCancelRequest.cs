namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// API request object for cancelling a payment order.
/// </summary>
public class PaymentOrderCancelRequest
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderCancelRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">Unique reference from the merchant system.</param>
    /// <param name="description">Textual description for why the cancel occurs.</param>
    public PaymentOrderCancelRequest(string payeeReference, string description)
    {
        Transaction = new PaymentOrderCancelTransaction(payeeReference, description);
    }

    /// <summary>
    /// Transactional details holding the payee reference, and a description of the cancellation.
    /// </summary>
    public PaymentOrderCancelTransaction Transaction { get; }
}