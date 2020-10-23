namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentCancelRequest
    {
        public CardPaymentCancelRequest(string payeeReference, string description)
        {
            this.Transaction = new CardPaymentCancelTransaction(payeeReference, description);
        }

        public CardPaymentCancelTransaction Transaction { get; }

        public string Description => this.Transaction.Description;

        public string PayeeReference => this.Transaction.PayeeReference;
    }
}