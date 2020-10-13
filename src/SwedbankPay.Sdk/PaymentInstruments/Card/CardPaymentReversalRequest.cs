namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentReversalRequest : ICardPaymentReversalRequest
    {
        public CardPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CardPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }
    }
}