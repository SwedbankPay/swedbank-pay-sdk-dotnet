namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancelTransaction
    {
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