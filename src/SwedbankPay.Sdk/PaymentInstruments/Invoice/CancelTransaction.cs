namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Transactional details for cancelling a transaction.
    /// </summary>
    public class CancelTransaction : ICancelTransaction
    {
        /// <summary>
        /// Instantiates a new <see cref="CancelTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="transactionActivity">The <see cref="Operation"/> for this cancel.</param>
        /// <param name="payeeReference">A transactionally unique reference from the merchant system.</param>
        /// <param name="description">A textual description of the cancellation.</param>
        protected internal CancelTransaction(Operation transactionActivity, string payeeReference, string description)
        {
            TransactionActivity = transactionActivity;
            PayeeReference = payeeReference;
            Description = description;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Operation TransactionActivity { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeReference { get; }
    }
}