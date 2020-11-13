namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentCaptureRequest
    {
        public MobilePayPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Details on what is being captured in the current payment.
        /// </summary>
        public CaptureTransaction Transaction { get; }
    }
}