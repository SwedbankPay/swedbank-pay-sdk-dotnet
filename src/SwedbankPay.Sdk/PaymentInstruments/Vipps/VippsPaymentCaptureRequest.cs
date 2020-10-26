using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentCaptureRequest
    {
        public VippsPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new VippsPaymentCaptureTransaction(amount, vatAmount, description, payeeReference);
        }


        public VippsPaymentCaptureTransaction Transaction { get; }
    }
}
