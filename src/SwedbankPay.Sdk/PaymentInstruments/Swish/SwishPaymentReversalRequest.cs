namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// API request for reversing a captured Swish payment.
    /// </summary>
    public class SwishPaymentReversalRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="SwishPaymentReversalRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount to reverse on the payment.</param>
        /// <param name="vatAmount">The amount to reverse that was captured as value added taxes.</param>
        /// <param name="description">A textual description of the reversal.</param>
        /// <param name="payeeReference">Transactionally unique reference for this request.</param>
        public SwishPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new SwishPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Object with details on what to reverse.
        /// </summary>
        public SwishPaymentReversalTransaction Transaction { get; }
    }
}