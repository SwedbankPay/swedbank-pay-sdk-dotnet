#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion


namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Known operations for PaymentOrder.
    /// </summary>
    public static class PaymentOrderResourceOperations
    {
        /// <summary>
        /// Gets a aborted payment order.
        /// </summary>
        public const string AbortedPaymentOrder = "aborted-paymentorder";

        /// <summary>
        /// Creates a cancellation for a payment order.
        /// </summary>
        public const string CreatePaymentOrderCancel = "create-paymentorder-cancel";

        /// <summary>
        /// Creates a capture for the payment order.
        /// </summary>
        public const string CreatePaymentOrderCapture = "create-paymentorder-capture";

        /// <summary>
        /// Creates a reversal for the payment order.
        /// </summary>
        public const string CreatePaymentOrderReversal = "create-paymentorder-reversal";

        /// <summary>
        /// Gets a payment order that is paid.
        /// </summary>
        public const string PaidPaymentOrder = "paid-paymentorder";

        /// <summary>
        /// Operation for redirecting payer.
        /// </summary>
        public const string RedirectPaymentOrder = "redirect-paymentorder";

        /// <summary>
        /// Operation for redirecting a payer for verification.
        /// </summary>
        public const string RedirectVerification = "redirect-verification";

        /// <summary>
        /// Operation to update the payment order to aborted state.
        /// </summary>
        public const string UpdatePaymentOrderAbort = "update-paymentorder-abort";

        /// <summary>
        /// Operation for updating the payment order.
        /// </summary>
        public const string UpdatePaymentOrderUpdateOrder = "update-paymentorder-updateorder";

        /// <summary>
        /// Operation to view the payment order in a iframe.
        /// </summary>
        public const string ViewPaymentOrder = "view-paymentorder";
    }
}