namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// A request for capturing a card payment.
    /// </summary>
    public class CardPaymentCaptureRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentCaptureRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Amount"/> to capture.</param>
        /// <param name="vatAmount">The <seealso cref="Amount"/> to capture in VAT.</param>
        /// <param name="description">A textual description of the capture.</param>
        /// <param name="payeeReference">A unique payee reference for this capture.</param>
        public CardPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CardPaymentCaptureTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Transactional details about the capture.
        /// </summary>
        public CardPaymentCaptureTransaction Transaction { get; }
    }
}