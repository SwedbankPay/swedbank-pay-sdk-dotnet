namespace SwedbankPay.Sdk.PaymentOrder;

public static class PaymentOrderResourceOperations
{
    // /// <summary>
    // /// Gets a aborted payment order.
    // /// </summary>
    // public const string AbortedPaymentOrder = "aborted-paymentorder";
    //
    // /// <summary>
    // /// Creates a cancellation for a payment order.
    // /// </summary>
    // public const string CreatePaymentOrderCancel = "create-paymentorder-cancel";
    //
    // /// <summary>
    // /// Creates a capture for the payment order.
    // /// </summary>
    // public const string CreatePaymentOrderCapture = "create-paymentorder-capture";
    //
    // /// <summary>
    // /// Creates a reversal for the payment order.
    // /// </summary>
    // public const string CreatePaymentOrderReversal = "create-paymentorder-reversal";
    //
    // /// <summary>
    // /// Gets a payment order that is paid.
    // /// </summary>
    // public const string PaidPaymentOrder = "paid-paymentorder";

    /// <summary>
    /// Operation for redirecting payer.
    /// </summary>
    public const string RedirectCheckout = "redirect-checkout";

    /// <summary>
    /// Operation to update the payment order to aborted state.
    /// </summary>
    public const string Abort = "abort";

    /// <summary>
    /// Operation for updating the payment order.
    /// </summary>
    public const string UpdateOrder = "update-order";

    /// <summary>
    /// Operation to view the payment order in a iframe.
    /// </summary>
    public const string ViewCheckout = "view-checkout";
}