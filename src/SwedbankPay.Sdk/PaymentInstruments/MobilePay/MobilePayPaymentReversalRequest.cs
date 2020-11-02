namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentReversalRequest
    {
        public MobilePayPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new MobilePayReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        public MobilePayReversalTransaction Transaction { get; }
    }
}