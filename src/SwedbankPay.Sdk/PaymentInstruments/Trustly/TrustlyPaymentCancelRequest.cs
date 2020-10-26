namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentCancelRequest
    {
        public TrustlyPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new TrustlyPaymentCancelTransaction(payeeReference, description);
        }

        public TrustlyPaymentCancelTransaction Transaction { get; set; }

        public string Description => Transaction.Description;

        public string PayeeReference => Transaction.PayeeReference;
    }
}