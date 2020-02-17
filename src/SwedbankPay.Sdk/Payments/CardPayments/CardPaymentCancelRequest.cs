namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentCancelRequest
    {
        public CardPaymentCancelRequest(string payeeReference, string description)
        {
            this.transaction = new CardPaymentCancelTransaction(payeeReference, description);
        }


        private CardPaymentCancelTransaction transaction { get; }

        public string Description => this.transaction.Description;

        public string PayeeReference => this.transaction.PayeeReference;

        private class CardPaymentCancelTransaction
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