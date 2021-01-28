namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// API oject for authorizing a Vipps payment.
    /// </summary>
    public class VippsPaymentAuthorizationRequest
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentAuthorizationRequest"/> with the provided <paramref name="msisdn"/>.
        /// </summary>
        /// <param name="msisdn">The payers phone number to be used with Vipps.</param>
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
