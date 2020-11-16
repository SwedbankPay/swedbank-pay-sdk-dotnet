namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationRequest
    {
        public VippsPaymentAuthorizationRequest(string msisdn)
        {
            Transaction = new VippsAuthorizationTransaction(msisdn);
        }

        /// <summary>
        /// Transactional detail holding the payers MSISDN.
        /// </summary>
        public VippsAuthorizationTransaction Transaction { get; }
    }
}
