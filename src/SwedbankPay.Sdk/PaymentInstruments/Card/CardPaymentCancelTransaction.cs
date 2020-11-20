namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentCancelTransaction
    {
        protected internal CardPaymentCancelTransaction(string payeeReference, string description)
        {
            PayeeReference = payeeReference;
            Description = description;
        }

        /// <summary>
        /// A human readable description of the cancellation.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }
    }
}