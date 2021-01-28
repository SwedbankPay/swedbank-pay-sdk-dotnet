namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transactional details for reversing a credit card payment.
    /// </summary>
    public class CardPaymentReversalTransaction : ICardPaymentReversalTransaction
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentReversalTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <see cref="Sdk.Amount"/> to be reversed back to the payer.</param>
        /// <param name="vatAmount">The <see cref="Sdk.Amount"/> that is VAT to be reversed.</param>
        /// <param name="description">A textual description of the reversal.</param>
        /// <param name="payeeReference">A transactionally unique reference to this reversal.</param>
        public CardPaymentReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Amount VatAmount { get; }
    }
}