namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public record PaymentOrderAbortRequestDetail
{
    private const string DefaultAbortReason = "CancelledByConsumer";
    private const string DefaultOperation = "Abort";
    
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderAbortRequestDetail"/> with default values.
    /// </summary>
    internal PaymentOrderAbortRequestDetail()
    {
        AbortReason = DefaultAbortReason;
    }
    
    /// <summary>
    /// The reason why the current payment is being aborted.
    /// </summary>
    public string AbortReason { get; set; }
    
    /// <summary>
    /// The Api operation.
    /// This is set to "Abort".
    /// </summary>
    public string Operation { get; } = DefaultOperation;
}