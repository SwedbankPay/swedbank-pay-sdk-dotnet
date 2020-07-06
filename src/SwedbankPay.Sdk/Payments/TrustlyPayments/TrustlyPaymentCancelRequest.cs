using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentCancelRequest
    {
        public TrustlyPaymentCancelRequest(string payeeReference, string description)
        {
            this.transaction = new TrustlyPaymentCancelTransaction(payeeReference, description);
        }

        [JsonProperty]
        private TrustlyPaymentCancelTransaction transaction { get; }

        public string Description => this.transaction.Description;

        public string PayeeReference => this.transaction.PayeeReference;

        private class TrustlyPaymentCancelTransaction
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