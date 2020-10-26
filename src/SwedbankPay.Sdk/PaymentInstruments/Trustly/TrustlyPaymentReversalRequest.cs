using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentReversalRequest
    {
        public TrustlyPaymentReversalRequest(Operation activity, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
        {
            Transaction = new TrustlyReversalTransaction(activity, amount, vatAmount, payeeReference, receiptReference, description);
        }


        public TrustlyReversalTransaction Transaction { get; }
    }
}
