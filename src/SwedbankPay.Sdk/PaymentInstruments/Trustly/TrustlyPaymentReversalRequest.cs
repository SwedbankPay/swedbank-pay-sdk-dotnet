namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentReversalRequest
    {
        public TrustlyPaymentReversalRequest(Operation activity, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
        {
            Transaction = new TrustlyReversalTransaction(activity, amount, vatAmount, payeeReference, receiptReference, description);
        }

        /// <summary>
        /// Data to reverse a Trustly payment.
        /// </summary>
        public TrustlyReversalTransaction Transaction { get; }
    }
}
