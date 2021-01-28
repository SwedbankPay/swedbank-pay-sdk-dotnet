namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// API request object for cancelling a Vipps payment.
    /// </summary>
    public class VippsPaymentCancelRequest
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentCancelRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="payeeReference">A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.</param>
        /// <param name="description">Textual description of the cancellation.</param>
        public VippsPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Details on cancelling a Vipps payment.
        /// </summary>
        public CancelTransaction Transaction { get; }
    }    
}