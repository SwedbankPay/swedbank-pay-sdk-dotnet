using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentCaptureRequest
    {
        public MobilePayPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, description, payeeReference);
        }


        public CaptureTransaction Transaction { get; }
    }
}