namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object wrapping a cancellation request for a Mobile Pay payment.
    /// </summary>
    public class MobilePayPaymentCancelRequest
    {
        /// <summary>
        /// Instantiates a <see cref="MobilePayPaymentCancelRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="payeeReference">Transactionally unique reference set by the merchant system.</param>
        /// <param name="description">A textual description of the cancellation.</param>
        public MobilePayPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Details on why the current payment is being cancelled.
        /// </summary>
        public CancelTransaction Transaction { get; }
    }
}
