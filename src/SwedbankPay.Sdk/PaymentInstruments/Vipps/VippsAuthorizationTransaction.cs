namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsAuthorizationTransaction
    {
        protected internal VippsAuthorizationTransaction(string msisdn)
        {
            Msisdn = msisdn;
        }
        public string Msisdn { get; }
    }
}
