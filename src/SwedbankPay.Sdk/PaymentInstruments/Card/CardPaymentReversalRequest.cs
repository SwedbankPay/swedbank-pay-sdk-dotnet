namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentReversalRequest
    {
        public CardPaymentReversalRequest(Amount amount, string description, string payeeReference, Amount vatAmount)
        {
            Transaction = new CardPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        public CardPaymentReversalTransaction Transaction { get; }
    }
}