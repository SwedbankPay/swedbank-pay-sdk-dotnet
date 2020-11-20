namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentCancelRequest
    {
        public CardPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CardPaymentCancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Transactional details about the cancellation.
        /// </summary>
        public CardPaymentCancelTransaction Transaction { get; }
    }
}