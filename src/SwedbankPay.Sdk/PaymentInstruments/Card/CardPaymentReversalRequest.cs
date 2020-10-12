namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentReversalRequest : ICardPaymentReversalRequest
    {
        public CardPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CardPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        public CardPaymentReversalTransaction Transaction { get; set; }

        public Amount Amount => this.Transaction.Amount;
        public string Description => this.Transaction.Description;
        public string PayeeReference => this.Transaction.PayeeReference;
        public Amount VatAmount => this.Transaction.VatAmount;
    }
}