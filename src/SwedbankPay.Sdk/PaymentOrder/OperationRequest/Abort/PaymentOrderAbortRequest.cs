using System.Text.RegularExpressions;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;

/// <summary>
/// API request object for aborting a payment order.
/// </summary>
public record PaymentOrderAbortRequest
{
    private static readonly Regex ValidAbortReasonRegex = new Regex(@"^[a-zA-Z0-9]+$");
    
    public PaymentOrderAbortRequest(string abortReason)
    {
        ValidateAbortReason(abortReason);
        PaymentOrder.AbortReason = abortReason;
    }
    
    public PaymentOrderAbortRequestDetail PaymentOrder { get; } = new();

    private void ValidateAbortReason(string abortReason)
    {
        if (!ValidAbortReasonRegex.IsMatch(abortReason))
        {
            throw new ArgumentException(@"Abort reason must match the regular expression '\w*'");
        }
    }
}