namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Transactioncal details for cancelling a payment order.
    /// </summary>
    public class PaymentOrderCancelTransaction
    {
        /// <summary>
        /// Instantiates a <see cref="PaymentOrderCancelTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="payeeReference">Unique reference from the merchant system.</param>
        /// <param name="description">Textual description for why the cancel occurs.</param>
        protected internal PaymentOrderCancelTransaction(string payeeReference, string description)
        {
            PayeeReference = payeeReference;
            Description = description;
        }

        /// <summary>
        /// A textual description of the cancel.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }
    }
}