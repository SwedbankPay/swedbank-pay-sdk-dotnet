namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public class VippsPaymentAuthorizationRequest
    {
        public VippsPaymentAuthorizationRequest(string msisdn)
        {
            Transaction = new AuthorizationTransaction(msisdn);
        }


        public AuthorizationTransaction Transaction { get; }

        public class AuthorizationTransaction
        {
            protected internal AuthorizationTransaction(string msisdn)
            {
                Msisdn = msisdn;
            }
            public string Msisdn { get; }
        }
    }
}