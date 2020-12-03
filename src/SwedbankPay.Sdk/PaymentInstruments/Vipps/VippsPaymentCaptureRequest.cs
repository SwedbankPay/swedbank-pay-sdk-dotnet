namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Transactional details for capturing a Vipps payment.
    /// </summary>
    public class VippsPaymentCaptureRequest
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentCaptureRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount of funds to capture.</param>
        /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="payeeReference">Transactionally unique reference to this capture transaction.</param>
        public VippsPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new VippsPaymentCaptureTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Transactional details on capturing a Vipps payment.
        /// </summary>
        public VippsPaymentCaptureTransaction Transaction { get; }
    }
}
