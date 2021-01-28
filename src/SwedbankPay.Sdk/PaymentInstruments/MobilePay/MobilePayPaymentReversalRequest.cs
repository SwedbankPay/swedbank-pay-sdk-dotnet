namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object describing a reversal request for a Mobile Pay payment.
    /// </summary>
    public class MobilePayPaymentReversalRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="MobilePayPaymentReversalRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Amount"/> to reverse on the payment.</param>
        /// <param name="vatAmount">The <seealso cref="Amount"/> to reverse on the payment as VAT.</param>
        /// <param name="description">A textual description about the payment.</param>
        /// <param name="payeeReference">Transactionally unique reference to this payment operation.</param>
        public MobilePayPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new MobilePayReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Information on how to reverse the MobilePay payment.
        /// </summary>
        public MobilePayReversalTransaction Transaction { get; }
    }
}