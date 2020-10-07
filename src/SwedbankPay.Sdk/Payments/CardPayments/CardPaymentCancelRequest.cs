namespace SwedbankPay.Sdk.Payments.CardPayments
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

        public class CardPaymentCancelTransaction
        {
            protected internal CardPaymentCancelTransaction(string payeeReference, string description)
            {
                PayeeReference = payeeReference;
                Description = description;
            }


            public string Description { get; }

            public string PayeeReference { get; }
        }
    }
}