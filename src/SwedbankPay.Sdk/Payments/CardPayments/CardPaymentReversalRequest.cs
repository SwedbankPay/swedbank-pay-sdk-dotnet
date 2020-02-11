namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentReversalRequest
    {
        public CardPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CardPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        public CardPaymentReversalTransaction Transaction { get; }
    }
}