namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;

internal record PaymentOrderAbortRequestDetailDto
{
    internal PaymentOrderAbortRequestDetailDto(PaymentOrderAbortRequestDetail paymentOrderAbortRequestDetail)
    {
        AbortReason = paymentOrderAbortRequestDetail.AbortReason;
        Operation = paymentOrderAbortRequestDetail.Operation;
    }

    /// <summary>
    /// The reason why the current payment is being aborted.
    /// </summary>
    public string? AbortReason { get; }

    /// <summary>
    /// The Api operation.
    /// This is set to "Abort".
    /// </summary>
    public string Operation { get; }
}