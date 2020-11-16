namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsAuthorizationTransaction
    {
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
