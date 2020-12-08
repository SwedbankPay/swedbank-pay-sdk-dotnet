namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API request object for aborting a payment order.
    /// </summary>
    public class PaymentOrderAbortRequest
    {
        /// <summary>
        /// Instantiates a <see cref="PaymentOrderAbortRequest"/> with the provided <paramref name="abortReason"/>.
        /// </summary>
        /// <param name="abortReason">A textual reason for the abort.</param>
        public PaymentOrderAbortRequest(string abortReason)
        {
            PaymentOrder.AbortReason = abortReason;
        }

        /// <summary>
        /// Transactional details for aborting a payment order.
        /// Has default values.
        /// </summary>
        public PaymentOrderAbortRequestDetails PaymentOrder { get; set; } = new PaymentOrderAbortRequestDetails();
    }
}