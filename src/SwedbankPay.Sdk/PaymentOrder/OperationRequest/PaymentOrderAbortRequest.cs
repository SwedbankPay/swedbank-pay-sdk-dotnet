using System.Text.RegularExpressions;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

/// <summary>
/// API request object for aborting a payment order.
/// </summary>
public record PaymentOrderAbortRequest
{
    private static readonly Regex ValidRegexMatch = new Regex(@"^[a-zA-Z0-9]+$");

    /// <summary>
    /// Instantiates a <see cref="PaymentOrderAbortRequest"/> with the provided <paramref name="abortReason"/>.
    /// </summary>
    /// <param name="abortReason">A textual reason for the abort.</param>
    public PaymentOrderAbortRequest(string abortReason)
    {
        if (!ValidRegexMatch.IsMatch(abortReason))
        {
            throw new ArgumentException(@"Abort reason must match the regular expression '\w*'");
        }
        PaymentOrder.AbortReason = abortReason;
    }

    /// <summary>
    /// Transactional details for aborting a payment order.
    /// Has default values.
    /// </summary>
    public PaymentOrderAbortRequestDetail PaymentOrder { get; } = new();
}