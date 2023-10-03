namespace SwedbankPay.Sdk.PaymentOrder;

public static class PaymentOrderResourceOperations
{
    /// <summary>
    /// Operation for updating the payment order.
    /// </summary>
    public const string UpdateOrder = "update-order";
    
    /// <summary>
    /// Operation to update the payment order to aborted state.
    /// </summary>
    public const string Abort = "abort";
    
    /// <summary>
    /// Creates a cancellation for a payment order.
    /// </summary>
    public const string Cancel = "cancel";
    
    /// <summary>
    /// Creates a capture for the payment order.
    /// </summary>
    public const string Capture = "capture";
    
    /// <summary>
    /// Creates a reversal for the payment order.
    /// </summary>
    public const string Reversal = "reversal";
    
    /// <summary>
    /// Operation for redirecting payer.
    /// </summary>
    public const string RedirectCheckout = "redirect-checkout";

    /// <summary>
    /// Operation to view the payment order in a iframe.
    /// </summary>
    public const string ViewCheckout = "view-checkout";
}