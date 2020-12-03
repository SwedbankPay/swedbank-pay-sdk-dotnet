namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API request object for aborting a payment order.
    /// </summary>
    public class PaymentOrderAbortRequest
    {
        /// <summary>
        /// Transactional details for aborting a payment order.
        /// Has default values.
        /// </summary>
        public PaymentOrderAbortRequestDetails PaymentOrder { get; set; } = new PaymentOrderAbortRequestDetails();
    }
}