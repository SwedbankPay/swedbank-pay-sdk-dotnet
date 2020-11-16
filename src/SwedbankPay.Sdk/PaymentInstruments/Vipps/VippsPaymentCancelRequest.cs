namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentCancelRequest
    {
        public VippsPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Details on cancelling a Vipps payment.
        /// </summary>
        public CancelTransaction Transaction { get; }
    }    
}