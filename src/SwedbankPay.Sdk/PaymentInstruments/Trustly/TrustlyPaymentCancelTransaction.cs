namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
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