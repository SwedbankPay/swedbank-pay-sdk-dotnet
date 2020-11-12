namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// A request for reversing an already
    /// captured payment.
    /// </summary>
    public class CardPaymentReversalRequest
    {
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