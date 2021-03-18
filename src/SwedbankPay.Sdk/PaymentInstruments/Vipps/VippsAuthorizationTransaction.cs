namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Object for authorizing a transaction with Vipps.
    /// </summary>
    public class VippsAuthorizationTransaction
    {
        /// <summary>
        /// Instantiates a <see cref="VippsAuthorizationTransaction"/> with the provided <paramref name="msisdn"/>.
        /// </summary>
        /// <param name="msisdn">The payers MSISDN.</param>
        public VippsAuthorizationTransaction(string msisdn)
        {
            Msisdn = msisdn;
        }

        /// <summary>
        /// The payers MSISDN, if set will autofill the payment UI.
        /// </summary>
        public string Msisdn { get; }
    }
}
