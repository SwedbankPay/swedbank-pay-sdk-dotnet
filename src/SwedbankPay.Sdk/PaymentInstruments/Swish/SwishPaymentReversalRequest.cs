namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentReversalRequest
    {
        public SwishPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new SwishPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        public SwishPaymentReversalTransaction Transaction { get; }
    }
}