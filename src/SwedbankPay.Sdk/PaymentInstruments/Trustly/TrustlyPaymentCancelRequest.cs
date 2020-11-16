namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentCancelRequest
    {
        public TrustlyPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new TrustlyPaymentCancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Transactional details about cancelling a Trustly payment.
        /// </summary>
        public TrustlyPaymentCancelTransaction Transaction { get; }
    }
}