namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentCancelRequest
    {
        public MobilePayPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }


        public CancelTransaction Transaction { get; }
    }
}
