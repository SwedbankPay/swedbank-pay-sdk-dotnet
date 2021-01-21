namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// A request for reversing an already
    /// captured payment.
    /// </summary>
    public class CardPaymentReversalRequest
    {
        /// <summary>
        /// Instantiates a new <seealso cref="CardPaymentReversalRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Amount"/> to be reversed.</param>
        /// <param name="description">A textual description of the reversal.</param>
        /// <param name="payeeReference">A transactionally unique payee reference from the merchant system.</param>
        /// <param name="vatAmount">The Value Added Taxes to be reversed.</param>
        public CardPaymentReversalRequest(Amount amount, string description, string payeeReference, Amount vatAmount)
        {
            Transaction = new CardPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// <see cref="CardPaymentReversalTransaction"/> with information
        /// needed to reverse a payment.
        /// </summary>
        public CardPaymentReversalTransaction Transaction { get; }
    }
}