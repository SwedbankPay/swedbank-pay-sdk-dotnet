namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentCancelRequest
    {
        public MobilePayPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Details on why the current payment is being cancelled.
        /// </summary>
        public CancelTransaction Transaction { get; }
    }
}
