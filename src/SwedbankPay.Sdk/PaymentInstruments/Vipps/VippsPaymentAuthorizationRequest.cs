namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationRequest
    {
        public VippsPaymentAuthorizationRequest(string msisdn)
        {
            Transaction = new VippsAuthorizationTransaction(msisdn);
        }


        public VippsAuthorizationTransaction Transaction { get; }
    }
}
