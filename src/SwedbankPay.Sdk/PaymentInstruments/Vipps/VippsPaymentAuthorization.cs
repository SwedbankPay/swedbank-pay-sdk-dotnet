namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorization : IdLink, IVippsPaymentAuthorization
    {
        public VippsPaymentAuthorization(
                             string vippsTransactionId,
                             string mobileNumber,
                             AuthorizationTransaction transaction)
        {
            VippsTransactionId = vippsTransactionId;
            MobileNumber = mobileNumber;
            Transaction = transaction;
        }


        public string VippsTransactionId { get; }
        public string MobileNumber { get; }
        public AuthorizationTransaction Transaction { get; }
    }
}