namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentCaptureRequest
    {
        public VippsPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new VippsPaymentCaptureTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Transactional details on capturing a Vipps payment.
        /// </summary>
        public VippsPaymentCaptureTransaction Transaction { get; }
    }
}
