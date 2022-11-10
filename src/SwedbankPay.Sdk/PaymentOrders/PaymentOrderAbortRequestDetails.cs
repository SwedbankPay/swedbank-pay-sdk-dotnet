namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Transactional details for aborting a payment order.
/// </summary>
public class PaymentOrderAbortRequestDetails
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderAbortRequestDetails"/> with default values.
    /// </summary>
    public PaymentOrderAbortRequestDetails()
    {
        AbortReason = "CancelledByConsumer";
    }

    /// <summary>
    /// The reason why the current payment is being aborted.
    /// </summary>
    public string AbortReason { get; set; }

    /// <summary>
    /// The Api operation.
    /// This is set to "Abort".
    /// </summary>
    public string Operation { get; } = "Abort";
}