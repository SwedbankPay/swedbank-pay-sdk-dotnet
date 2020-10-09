namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentCancelRequest
    {
        public TrustlyPaymentCancelRequest(string payeeReference, string description)
        {
            this.Transaction = new TrustlyPaymentCancelTransaction(payeeReference, description);
        }

        public TrustlyPaymentCancelTransaction Transaction { get; set; }

        public string Description => this.Transaction.Description;

        public string PayeeReference => this.Transaction.PayeeReference;

        public class TrustlyPaymentCancelTransaction
        {
            protected internal TrustlyPaymentCancelTransaction(string payeeReference, string description)
            {
                PayeeReference = payeeReference;
                Description = description;
            }


            public string Description { get; }

            public string PayeeReference { get; }
        }
    }
}