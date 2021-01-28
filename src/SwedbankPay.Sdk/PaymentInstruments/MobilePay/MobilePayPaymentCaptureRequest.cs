namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object for describing a Mobile Pay capture request.
    /// </summary>
    public class MobilePayPaymentCaptureRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="MobilePayPaymentCaptureRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Amount"/> to capture for this payment.</param>
        /// <param name="vatAmount">The <seealso cref="Amount"/> to capture as VAT for this payment.</param>
        /// <param name="description">A textual description of the purchase.</param>
        /// <param name="payeeReference">Transactionally unique reference for this payment, set by the merchant system.</param>
        public MobilePayPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Details on what is being captured in the current payment.
        /// </summary>
        public CaptureTransaction Transaction { get; }
    }
}